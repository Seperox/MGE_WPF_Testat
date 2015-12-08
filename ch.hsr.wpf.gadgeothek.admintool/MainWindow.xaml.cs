using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ch.hsr.wpf.gadgeothek.service;
using ch.hsr.wpf.gadgeothek.domain;
using System.Configuration;


namespace ch.hsr.wpf.gadgeothek.admintool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LibraryAdminService service;
        public ObservableCollection<Gadget> Gadgets { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            service = new LibraryAdminService(ConfigurationSettings.AppSettings.Get("server"));

            this.DataContext = this;
            Gadgets = new ObservableCollection<Gadget>(service.GetAllGadgets());
            List<domain.Loan> loans = service.GetAllLoans();
            List<domain.Customer> customers = service.GetAllCustomers();
            List<domain.Reservation> reservations = service.GetAllReservations();

            //gadgetGrid.ItemsSource = gadgets;
            loanGrid.ItemsSource = loans;
            reservationGrid.ItemsSource = reservations;
            customerGrid.ItemsSource = customers;

        }



        private void NewGadget_Click(object sender, RoutedEventArgs e)
        {
            addGadget addWindow = new addGadget();
            addWindow.Show();
            addWindow.Closed += delegate(object s, EventArgs a)
            {
                refreshGadgets();
            };
        }

        private void DeleteGadget_Click(object sender, RoutedEventArgs e)
        {
            if (gadgetGrid.SelectedItem == null)
            {
                MessageBox.Show("No Item selected!");
            }else
            {
                Gadget selectedGadget = (Gadget)gadgetGrid.SelectedItem;

                deleteGadget deleteWindow = new deleteGadget(selectedGadget);
                deleteWindow.Show();
                deleteWindow.Yes_Button.Click += delegate
                {
                    if (service.DeleteGadget(selectedGadget))
                    {
                        MessageBox.Show("Gadget successfully deleted!");
                        deleteWindow.Close();
                    }
                    else
                    {
                        MessageBox.Show("Operation failed!");
                    }
                };
                deleteWindow.Closed += delegate (object s, EventArgs a)
                {
                    refreshGadgets();
                };
            }
        }

        private void refreshGadgets()
        {
            Gadgets.Clear();
            service.GetAllGadgets().ForEach(g => Gadgets.Add(g));
        }
    }
}

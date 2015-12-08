using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Configuration;
using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;

namespace ch.hsr.wpf.gadgeothek.admintool
{
    /// <summary>
    /// Interaction logic for addGadget.xaml
    /// </summary>
    public partial class addGadget : Window
    {
        public addGadget()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Gadget gadget = new Gadget(name.Text.ToString());
            double isDouble;
            double.TryParse(price.Text.ToString(), out isDouble);
            gadget.Price = isDouble;
            gadget.Manufacturer = manufacturer.Text.ToString();
            LibraryAdminService service = new LibraryAdminService(ConfigurationSettings.AppSettings.Get("server"));
            if (service.AddGadget(gadget))
            {
                MessageBox.Show("Gadget successfully added!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Operation failed!");
            }
        }
    }
}

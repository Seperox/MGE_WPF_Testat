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
using ch.hsr.wpf.gadgeothek.service;
using ch.hsr.wpf.gadgeothek.domain;

namespace ch.hsr.wpf.gadgeothek.admintool
{
    /// <summary>
    /// Interaction logic for deleteGadget.xaml
    /// </summary>
    public partial class deleteGadget : Window
    {
        private LibraryAdminService service;
        private Gadget gadget;

        public deleteGadget(Gadget gadget)
        {
            this.gadget = gadget;
            InitializeComponent();

            InventoryNr.Text = gadget.InventoryNumber;
            Condition.Text = gadget.Condition.ToString();
            Price.Text = gadget.Price.ToString();
            Manufacturer.Text = gadget.Manufacturer;
            Name.Text = gadget.Name;


        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}


using Diplom1;

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DIplom.AddPages
{
    /// <summary>
    /// Interaction logic for Add_Klients_Page.xaml
    /// </summary>
    public partial class Add_Klients_Page : Page
    {
        Klienti klienti;
        public Add_Klients_Page(Klienti kl)
        {
            this.klienti = kl;
            DataContext = klienti;
            InitializeComponent();
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (klienti.KlientId == 0)
            {
                CoreModel.init().Klientis.Add(klienti);
            }
            CoreModel.init().SaveChanges();
            NavigationService.GoBack();
        }
    }
}

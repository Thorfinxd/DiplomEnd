
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

namespace Diplom1.AddPages
{
    /// <summary>
    /// Interaction logic for Add_Sklad_Page.xaml
    /// </summary>
    public partial class Add_Sklad_Page : Page
    {
        Sklad sklad;
        public Add_Sklad_Page( Sklad sklads)
        {
            this.sklad = sklads;
            DataContext = sklad;
            InitializeComponent();
            
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(sklad.Skladid == 0)
            {
                CoreModel.init().Sklads.Add(sklad);
            }
            CoreModel.init().SaveChanges();
            NavigationService.GoBack();
        }
    }
}

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
    /// Interaction logic for Add_Tovar_Page.xaml
    /// </summary>
    public partial class Add_Tovar_Page : Page
    {
        Tovar tovar;
        public Add_Tovar_Page(Tovar tov)
        {
            this.tovar = tov;
            DataContext = tovar;
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (tovar.TovarId == 0)
            {
                CoreModel.init().Tovars.Add(tovar);
            }
            CoreModel.init().SaveChanges();
            NavigationService.GoBack();
        }
    }
}

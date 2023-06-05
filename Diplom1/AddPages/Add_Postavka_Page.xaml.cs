using Diplom1.BDModels;
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
    /// Interaction logic for Add_Postavka_Page.xaml
    /// </summary>
    public partial class Add_Postavka_Page : Page
    {
        Postavka postavka;
        public Add_Postavka_Page( Postavka post)
        {
            this.postavka = post;
            DataContext = postavka;        
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (postavka.PostavkaId == 0)
            {
                CoreModel.init().Postavkas.Add(postavka);
            }
            CoreModel.init().SaveChanges();
            NavigationService.GoBack();
        }
    }
}

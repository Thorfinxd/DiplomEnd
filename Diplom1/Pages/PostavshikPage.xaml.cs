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

namespace Diplom1.Pages
{
    /// <summary>
    /// Interaction logic for PostavshikPage.xaml
    /// </summary>
    public partial class PostavshikPage : Page
    {
        public PostavshikPage()
        {
            InitializeComponent();
            Update();
        }

        private void Update()
        {
             DGVPostavshik.ItemsSource = CoreModel.init().Postavshiks.ToList();
            
        }
    }
}

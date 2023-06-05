using DIplom.Pages;
using Diplom1;
using Diplom1.Pages;
using Diplom1.Windows;
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

namespace DIplom.Windows
{
    /// <summary>
    /// Interaction logic for Window_menu_polz.xaml
    /// </summary>
    public partial class Window_menu_polz : Window
    {
        public Window_menu_polz()
        {
            InitializeComponent();
        }
      

        private void Show_Tovar_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new ListView_Tovar_Page());
        }

        private void Window_Mouse_Down(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Show_Postavshik_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new PostavshikPage());
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void Show_Orders_Click(object sender, RoutedEventArgs e)
        {
            Orders_Add_User_Window window = new Orders_Add_User_Window(new Order());
            window.Show();
            
        }
    }
}

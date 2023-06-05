using DIplom.Pages;
using Diplom1.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DIplom.Windows
{
    /// <summary>
    /// Interaction logic for Window_menu_admin.xaml
    /// </summary>
    public partial class Window_menu_admin : Window
    {
        public Window_menu_admin()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            PropReload();

            if (Diplom1.Properties.Settings.Default.Language == "ru")
            {
                cbLearn.SelectedIndex = 1;
            }
            else
            {
                cbLearn.SelectedIndex = 0;
            }
        }


        private void PropReload()
        {
            ResourceDictionary dictionary = new ResourceDictionary();

            Diplom1.Properties.Settings.Default.Save();

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
            if (Diplom1.Properties.Settings.Default.Language == "ru")
            {
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Localisation/Localisation.ru.xaml", UriKind.Relative) });
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Localisation/Localisation.en.xaml", UriKind.Relative) });
            }
        }


        private void UpdateLocale()
        {
            ResourceDictionary resourceDictionary;
            if (Diplom1.Properties.Settings.Default.Language == "RU")
            {
                resourceDictionary = new ResourceDictionary { Source = new Uri("Localisation/Localisation.ru.xaml", UriKind.Relative) };
            }
            else
            {
                resourceDictionary = new ResourceDictionary { Source = new Uri("Localisation/Localisation.en.xaml", UriKind.Relative) };
            }
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Diplom1.Properties.Settings.Default.Language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Diplom1.Properties.Settings.Default.Language);
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }




        private void Show_Klients_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new KlientsPage());
        }

        private void Show_Tovar_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new ListView_Tovar_Page());
        }

        private void Show_Postavka_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new PostavkaPage());
        }

        private void Window_Mouse_Down(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Show_SD_Click(object sender, RoutedEventArgs e)
        {
            TodoWindow todoWindow = new TodoWindow();
            todoWindow.Show();
        }

        private void Show_Sklad_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new SkladPage());
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
            if(WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void cbLangChancked(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem localItem = cbLearn.SelectedItem as ComboBoxItem;
            Diplom1.Properties.Settings.Default.Language = localItem.Tag as string;
            Diplom1.Properties.Settings.Default.Save();
            UpdateLocale();
        }

        private void Show_Orders_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new Orders_Page());
        }
    }
}

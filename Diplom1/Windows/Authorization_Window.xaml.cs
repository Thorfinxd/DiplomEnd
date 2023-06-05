using Diplom1.BDModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Authorization_Window.xaml
    /// </summary>
    public partial class Authorization_Window : Window
    {
        public Authorization_Window()
        {
            InitializeComponent();
        //    PropReload();

        //    if (Diplom1.Properties.Settings.Default.Language == "ru")
        //    {
        //        cbLearn.SelectedIndex = 1;
        //    }
        //    else
        //    {
        //        cbLearn.SelectedIndex = 0;
        //    }
        }


        //private void PropReload()
        //{
        //    ResourceDictionary dictionary = new ResourceDictionary();

        //    Diplom1.Properties.Settings.Default.Save();

        //    Application.Current.Resources.MergedDictionaries.Clear();
        //    Application.Current.Resources.MergedDictionaries.Add(dictionary);
        //    if (Diplom1.Properties.Settings.Default.Language == "ru")
        //    {
        //        Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Localisation/Localisation.ru.xaml", UriKind.Relative) });
        //    }
        //    else
        //    {
        //        Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Localisation/Localisation.en.xaml", UriKind.Relative) });
        //    }
        //}


        //private void UpdateLocale()
        //{
        //    ResourceDictionary resourceDictionary;
        //    if (Diplom1.Properties.Settings.Default.Language == "RU")
        //    {
        //        resourceDictionary = new ResourceDictionary { Source = new Uri("Localisation/Localisation.ru.xaml", UriKind.Relative) };
        //    }
        //    else
        //    {
        //        resourceDictionary = new ResourceDictionary { Source = new Uri("Localisation/Localisation.en.xaml", UriKind.Relative) };
        //    }
        //    Thread.CurrentThread.CurrentCulture = new CultureInfo(Diplom1.Properties.Settings.Default.Language);
        //    Thread.CurrentThread.CurrentUICulture = new CultureInfo(Diplom1.Properties.Settings.Default.Language);
        //    Application.Current.Resources.MergedDictionaries.Clear();
        //    Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        //}


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
                //Возможность перетаскивания окна
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
            //Сворачивание окна
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            //Остановка программы
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUser == null || txtPass == null)
            {
                MessageBox.Show("Вы ввели некорректные данные");
                //Если поля логина и пароля пустые, выводим сообщение
            }
            else
            {
                User user = CoreModel.init().Users.FirstOrDefault(p => p.UsersLogin == txtUser.Text && p.UsersPassword == txtPass.Text);
                //Подключение текстбоксов к данным логина и пароля из таблицы 

                if (user != null)
                    //Если пользователь не равен нулевому значению
                {
                    if (user.UsersRolesid == 1)
                    //Если роль пользователя равна 1
                    {
                        MessageBox.Show("Здравствуйте, вы клиент");
                        //Выводим соответствующее оповещение
                        Window_menu_polz wind = new Window_menu_polz();
                        //Переход на меню пользователя
                        wind.Show();
                        Hide();
                       
                        
                    }


                    if (user.UsersRolesid == 2)
                    {
                        MessageBox.Show("Здравствуйте, вы администратор");
                        Window_menu_admin wind = new Window_menu_admin();
                        wind.Show();
                        Hide();
                    }
                }
            }
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                //Если размер окна обычный, при нажатии разворачивается
            }
            else
            {
                WindowState = WindowState.Normal;
                //В ином случае сворачиваем до первоначальных размеров
                
            }
        }

        private void cbViewPass_Click(object sender, RoutedEventArgs e)
        {
            if(cbViewPass.IsChecked== true)
            {
                txtPass.Text = passbox.Password;
                txtPass.Visibility = Visibility.Visible;
                passbox.Visibility = Visibility.Hidden;
                //Если чек бокс активен, скрываем пассвордбокс
            }
            else
            {
                passbox.Password = txtPass.Text;
                txtPass.Visibility = Visibility.Hidden;
                passbox.Visibility = Visibility.Visible;
                // В ином случае скрываем текстбокс
            }
            
        }

        //private void cbLangChancked(object sender, SelectionChangedEventArgs e)
        //{
        //    ComboBoxItem localItem = cbLearn.SelectedItem as ComboBoxItem;
        //    Diplom1.Properties.Settings.Default.Language = localItem.Tag as string;
        //    Diplom1.Properties.Settings.Default.Save();
        //    UpdateLocale();
        //}
    }
    }
    


        
    

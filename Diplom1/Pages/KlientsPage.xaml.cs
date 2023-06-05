using DIplom.AddPages;
using Diplom1.BDModels;
using Diplom1.Classes;
using Microsoft.Win32;
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

namespace DIplom.Pages
{
    /// <summary>
    /// Interaction logic for KlientsPage.xaml
    /// </summary>
    public partial class KlientsPage : Page
    {
        public KlientsPage()
        {
            InitializeComponent();
            Update();
        }

        private void Update()
        {
            DGVKlients.ItemsSource = CoreModel.init().Klientis.ToList();

            List<Klienti> klients = CoreModel.init().Klientis.Where(t => t.KlientName.Contains(TbSearch.Text) || t.KlientAdres.Contains(TbSearch.Text)
            || t.KlientCompany.Contains(TbSearch.Text)).ToList();
            DGVKlients.ItemsSource = klients;
        }

        private void Del_Test_Click(object sender, RoutedEventArgs e)
        {
            if (DGVKlients.SelectedItems.Count > 1)
                return;


            Klienti KlientiDel = DGVKlients.SelectedItem as Klienti;

            if (MessageBox.Show("Delete ?", "Realyu wont delete ?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().Klientis.Remove(KlientiDel);
                CoreModel.init().SaveChanges();
                Update();
            }
        }

        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_Klients_Page(new Klienti()));
        }

        private void Redact_Show_Click(object sender, RoutedEventArgs e)
        {
            Klienti KlientiEdit = DGVKlients.SelectedItem as Klienti;
            NavigationService.Navigate(new Add_Klients_Page(KlientiEdit));
            Update();
        }

        private void Klients_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();
        }

        private void Search_Tbox_Changed(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void btExportClick(object sender, RoutedEventArgs e)
        {

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Файлы excel|*.xlsx";
            if (dialog.ShowDialog() == true)
            {
                List<Klienti> klientiTrainesses = CoreModel.init().Klientis.ToList();
                string[,] values = new string[klientiTrainesses.Count + 1, 6];

                values[0, 0] = "Имя";
                values[0, 1] = "Фамилия";
                values[0, 2] = "Отчество";
                values[0, 3] = "Компания";
                values[0, 4] = "Адрес";
                values[0, 5] = "Телефон";

                for (int i = 0; i < klientiTrainesses.Count; i++)
                {
                    values[i + 1, 0] = klientiTrainesses[i].KlientName;
                    values[i + 1, 1] = klientiTrainesses[i].KlientSurname;
                    values[i + 1, 2] = klientiTrainesses[i].KlientSecondName;
                    values[i + 1, 3] = klientiTrainesses[i].KlientCompany;
                    values[i + 1, 4] = klientiTrainesses[i].KlientAdres;
                    values[i + 1, 5] = klientiTrainesses[i].KlientPhone.ToString();
                }
                ExcelClass.saveExcel(dialog.FileName, "Клиенты", values);
            }

            }
    }
}

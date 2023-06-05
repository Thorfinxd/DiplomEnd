using DIplom.AddPages;
using Diplom1.AddPages;
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

namespace Diplom1.Pages
{
    /// <summary>
    /// Interaction logic for SkladPage.xaml
    /// </summary>
    public partial class SkladPage : Page
    {
        public SkladPage()
        {
            InitializeComponent();
            Update();
        }

        private void Update()
        {
            DGVSklad.ItemsSource = CoreModel.init().Sklads.ToList();

            List<Sklad> sklads = CoreModel.init().Sklads.Where(t => t.NameTov.Contains(TbSearch.Text)).ToList();
            DGVSklad.ItemsSource = sklads;
        }

        private void Sklad_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();
        }

        private void Search_Tbox_Changed(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void Del_Test_Click(object sender, RoutedEventArgs e)
        {
            if (DGVSklad.SelectedItems.Count > 1)
                return;


            Sklad SkladDel = DGVSklad.SelectedItem as Sklad;

            if (MessageBox.Show("Delete ?", "Realyu wont delete ?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().Sklads.Remove(SkladDel);
                CoreModel.init().SaveChanges();
                Update();
            }
        }

        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_Sklad_Page(new Sklad()));
        }

        private void Redact_Show_Click(object sender, RoutedEventArgs e)
        {
            Sklad SkladEdit = DGVSklad.SelectedItem as Sklad;
            NavigationService.Navigate(new Add_Sklad_Page(SkladEdit));
            Update();
        }

        private void btExportClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Файлы excel|*.xlsx";
            if (dialog.ShowDialog() == true)
            {
                List<Sklad> sklads = CoreModel.init().Sklads.ToList();
                string[,] values = new string[sklads.Count + 1, 2];

                values[0, 0] = "Наименование товара";
                values[0, 1] = " Остаток";
               

                for (int i = 0; i < sklads.Count; i++)
                {
                    values[i + 1, 0] = sklads[i].NameTov;
                    values[i + 1, 1] = sklads[i].Ostatok.ToString();
                   
                }
                ExcelClass.saveExcel(dialog.FileName, "Склад", values);
            }
        }
    }
}

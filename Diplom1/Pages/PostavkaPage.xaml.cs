using DIplom.AddPages;
using Diplom1;

using Diplom1.Classes;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for PostavkaPage.xaml
    /// </summary>
    public partial class PostavkaPage : Page
    {
        public PostavkaPage()
        {
            InitializeComponent();
            Update();

        }

        private void Update()
        {
            DGVPostavka.ItemsSource = CoreModel.init().Postavkas.ToList();

            List<Postavka> postavkas = CoreModel.init().Postavkas.Where(t => t.PostavkaNamePost.Contains(TbSearch.Text) || t.PostavkaNameTov.Contains(TbSearch.Text) 
            || t.PostavkaNameTov.Contains(TbSearch.Text)).ToList();
            DGVPostavka.ItemsSource = postavkas;
        }

        private void Del_Test_Click(object sender, RoutedEventArgs e)
        {
            if (DGVPostavka.SelectedItems.Count > 1)
                return;


            Postavka PostavkaDel = DGVPostavka.SelectedItem as Postavka;

            if (MessageBox.Show("Delete ?", "Realyu wont delete ?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().Postavkas.Remove(PostavkaDel);
                CoreModel.init().SaveChanges();
                Update();
            }
        }

        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_Postavka_Page(new Postavka()));
        }

        private void Redact_Show_Click(object sender, RoutedEventArgs e)
        {
            Postavka PostavkaEdit = DGVPostavka.SelectedItem as Postavka;
            NavigationService.Navigate(new Add_Postavka_Page(PostavkaEdit));
            Update();
        }

        private void Search_Tbox_Changed(object sender, TextChangedEventArgs e)
        {
            Update();           
        }

        private void Post_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();
        }

        private void btExportClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Файлы excel|*.xlsx";
            if (dialog.ShowDialog() == true)
            {
                List<Postavka> postavkas = CoreModel.init().Postavkas.ToList();
                string[,] values = new string[postavkas.Count + 1, 6];

                values[0, 0] = "Наименование товара";
                values[0, 1] = "Наименование поставщика";
                values[0, 2] = "Количество";
                values[0, 3] = "Сумма";
                values[0, 4] = "Дата";
                values[0, 5] = "Описание";

                for (int i = 0; i < postavkas.Count; i++)
                {
                    values[i + 1, 0] = postavkas[i].PostavkaNameTov;
                    values[i + 1, 1] = postavkas[i].PostavkaNamePost;
                    values[i + 1, 2] = postavkas[i].PostavkaKolvo.ToString();
                    values[i + 1, 3] = postavkas[i].PostavkaCena.ToString();
                    values[i + 1, 4] = postavkas[i].PostavkaDate.ToString();
                    values[i + 1, 5] = postavkas[i].PostavkaDesc;
                }
                ExcelClass.saveExcel(dialog.FileName, "Поставка", values);
            }
        }
    }
}

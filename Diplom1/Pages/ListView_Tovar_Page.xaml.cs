using DIplom.AddPages;
using Diplom1;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for ListView_Tovar_Page.xaml
    /// </summary>
    public partial class ListView_Tovar_Page : Page
    {
        public ListView_Tovar_Page()
        {
            InitializeComponent();           
            UpdateData();
            cmbSearchParametrs.Items.Add("Без сортировки ");
            cmbSearchParametrs.Items.Add("По возрастанию ");
            cmbSearchParametrs.Items.Add("По убыванию ");
            cmbSearchParametrs.SelectedIndex = 0;

            fltSearchParametrs.Items.Add("Без фильтров");
            fltSearchParametrs.Items.Add("Периферия");
            fltSearchParametrs.Items.Add("Услуга");
            fltSearchParametrs.SelectedIndex = 0;


        }

        private void UpdateData()
        {
            if (LV_Tovar == null)
            {
                return;
            }
            //IEnumerable<Tovar> tovars = CoreModel.init().Tovars.Where(p => p.NaimTov.Contains(TBSearch.Text)).ToList();            
            //LV_Tovar.ItemsSource = tovars;
            IEnumerable<Tovar> tovars = CoreModel.init().Tovars.Include(p => p.CategoryCategory).
                Where(p => p.NaimTov.Contains(TBSearch.Text)).ToList();



            if (cmbSearchParametrs.SelectedIndex == 0)
            {
                tovars.ToList(); 
            }
            if (cmbSearchParametrs.SelectedIndex == 1)
            {
                tovars = tovars.OrderByDescending(t=>t.NaimTov).ToList(); ;
            }
            if (cmbSearchParametrs.SelectedIndex == 2)
            {
                tovars = tovars.OrderBy(t => t.NaimTov).ToList(); ;
            }

            if(fltSearchParametrs.SelectedIndex != 0)
            {
                if (fltSearchParametrs.SelectedIndex == 0)
                    tovars = tovars.Where(c => c.CategoryCategory.CaterogyTovid == 0).ToList();
                else if(fltSearchParametrs.SelectedIndex == 1)
                    tovars = tovars.Where(c => c.CategoryCategory.CaterogyTovid == 1).ToList();
                else if (fltSearchParametrs.SelectedIndex == 2)
                    tovars = tovars.Where(c => c.CategoryCategory.CaterogyTovid == 2).ToList();
            }


            LV_Tovar.ItemsSource = tovars;


        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (LV_Tovar.SelectedItems.Count > 1)
                return;
            {
                Tovar TovarDel = LV_Tovar.SelectedItem as Tovar;

                if (MessageBox.Show("You want delete?", "Rly want?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    CoreModel.init().Tovars.Remove(TovarDel);
                    CoreModel.init().SaveChanges();
                    UpdateData();
                }
            }
        }

            private void Redact_Click(object sender, RoutedEventArgs e)
            {
                Tovar TovarEdit = LV_Tovar.SelectedItem as Tovar;
                NavigationService.Navigate(new Add_Tovar_Page(TovarEdit));
                UpdateData();
            }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_Tovar_Page(new Tovar()));
            UpdateData();
        }

        private void TB_Vis_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateData();
        }

        private void Search_Tbox_Changed(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void cmbSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void fltr_SelectChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
    }
    }


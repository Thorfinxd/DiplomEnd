using Diplom1.BdModels;
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
using Microsoft.EntityFrameworkCore;
using Diplom1.Windows;
using Diplom1.BDModels;
using Diplom1.Classes;
using Microsoft.Win32;

namespace Diplom1.Pages
{
    /// <summary>
    /// Interaction logic for Orders_Page.xaml
    /// </summary>
    public partial class Orders_Page : Page
    {
        public Orders_Page()
        {
            InitializeComponent();
            dgvOrders.ItemsSource = CoreModel.init().Orders.Include(o=>o.KlientiKlient).ToList();
        }
        void UpdateOrd()
        {
            dgvOrders.ItemsSource = CoreModel.init().Orders.Include(o => o.KlientiKlient).ToList();

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Order? ord = dgvOrders.SelectedItem as Order;
            if (ord != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить этот заказ?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    List<OrdersProduct> hasOrders = CoreModel.init().OrdersProducts.Where(o => o.OrdersId == ord.OrdersId).Include(o => o.Orders).Include(o => o.Products).ToList();
                    foreach (var oh in hasOrders)
                        CoreModel.init().OrdersProducts.Remove(oh);
                    CoreModel.init().SaveChanges();
                    CoreModel.init().Orders.Remove(ord);
                    CoreModel.init().SaveChanges();
                    UpdateOrd();

                }
            }
            else
                MessageBox.Show("Вы ничего не выбрали");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new Orders_AddWindow(new Order()).ShowDialog();
            UpdateOrd();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            Order? ord = dgvOrders.SelectedItem as Order;
            if (ord != null)
            {
                new Orders_AddWindow(ord).ShowDialog();
                UpdateOrd();
            }
            else
                MessageBox.Show("Вы ничего не выбрали");
        }

        private void btExportClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Файлы excel|*.xlsx";
            if (dialog.ShowDialog() == true)
            {
                List<Order> orders = CoreModel.init().Orders.ToList();
                string[,] values = new string[orders.Count + 1, 4];

                values[0, 0] = "id Заказа";
                values[0, 1] = "Дата создания";
                values[0, 2] = "ФИО клиента";
                values[0, 3] = "Телефон";



                for (int i = 0; i < orders.Count; i++)
                {
                    values[i + 1, 0] = orders[i].OrdersId.ToString();
                    values[i + 1, 1] = orders[i].OrdersDate.ToString();
                    values[i + 1, 2] = orders[i].KlientiKlient.kilentFIO;
                    values[i + 1, 3] = orders[i].KlientiKlient.KlientPhone.ToString();

                }
                ExcelClass.saveExcel(dialog.FileName, "Клиенты", values);
            }
        }
    }
}

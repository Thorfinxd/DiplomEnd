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
    }
}

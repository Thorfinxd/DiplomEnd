using Diplom1.BDModels;
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
using System.Windows.Shapes;

namespace Diplom1.Windows
{
    /// <summary>
    /// Interaction logic for Orders_Add_User_Window.xaml
    /// </summary>
    public partial class Orders_Add_User_Window : Window
    {

        Order order { get; set; }
        List<Tovar> tovars = new List<Tovar>();
        List<OrdersProduct> hasOrders = new List<OrdersProduct>();
        public Orders_Add_User_Window( Order ord)
        {
            InitializeComponent();
            order = ord;
            DataContext = ord;
            if (ord.OrdersId != 0)
            {
                dtpDate.SelectedDate = ord.OrdersDate;
            }
            List<Tovar> tovaaa = CoreModel.init().Tovars.ToList();
            foreach (var t in tovaaa)
                cmbTovars.Items.Add(t);
            cmbClients.ItemsSource = CoreModel.init().Klientis.ToList();
            hasOrders = CoreModel.init().OrdersProducts.Where(o => o.OrdersId == ord.OrdersId).Include(o => o.Orders).Include(o => o.Products).ToList();
            foreach (var oh in hasOrders)
            {
                Tovar? tovar = CoreModel.init().Tovars.FirstOrDefault(p => p.TovarId == oh.ProductsId);
                tovar.TovarsCount = oh.ProductsCount;
                tovars.Add(tovar);
                dgvTovars.Items.Add(tovar);
                cmbTovars.Items.Remove(tovar);

            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbClients.SelectedIndex >= 0)
                {
                    if (dtpDate.SelectedDate != null)
                    {
                        order.OrdersDate = (DateTime)dtpDate.SelectedDate;
                        foreach (var oh in hasOrders)
                            CoreModel.init().OrdersProducts.Remove(oh);
                        CoreModel.init().SaveChanges();
                        foreach (Tovar t in dgvTovars.Items)
                        {
                            OrdersProduct op = new OrdersProduct();
                            op.ProductsCount = t.TovarsCount;
                            op.ProductsId = t.TovarId;
                            order.OrdersProducts.Add(op);
                        }
                        if (order.OrdersId == 0)
                            CoreModel.init().Orders.Add(order);
                        CoreModel.init().SaveChanges();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Нет даты");
                }
                else
                    MessageBox.Show("Не выбрано фио");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTovars.SelectedItem != null)
            {
                int count = 1;
                if (tbTovarsCount.Text.Length == 0)
                    count = 1;
                else
                    count = Convert.ToInt32(tbTovarsCount.Text);

                if (count == 0)
                    count = 1;
                Tovar? t = cmbTovars.SelectedItem as Tovar;
                t.TovarsCount = count;
                dgvTovars.Items.Add(t);
                cmbTovars.Items.Remove(cmbTovars.SelectedItem);
            }
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (dgvTovars.SelectedItem != null)
            {
                cmbTovars.Items.Add(dgvTovars.SelectedItem);
                dgvTovars.Items.Remove(dgvTovars.SelectedItem);
            }
        }
    }


}
    


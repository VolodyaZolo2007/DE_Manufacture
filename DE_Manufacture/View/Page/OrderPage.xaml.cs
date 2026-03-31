using DE_Manufacture.Model;
using DE_Manufacture.View.Window;
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

namespace DE_Manufacture.View.Page
{
    /// <summary>
    /// Логика взаимодействия для OrderPaGe.xaml
    /// </summary>
    public partial class OrderPaGe : System.Windows.Controls.Page
    {
        private List<Order> _order;
        public OrderPaGe()
        {
            InitializeComponent();

            LoadData();
        }
        public void LoadData()
        {
            _order = App.context.Order.ToList();
            OrderLv.ItemsSource = _order;
        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = SearchTb.Text.ToLower();
            if (string.IsNullOrWhiteSpace(search))
            {
                LoadData();
                return;
            }

            OrderLv.ItemsSource = _order.Where(o => o.Number.ToString().ToLower().Contains(search) ||
                                                    o.TotalPrice.ToString().ToLower().Contains(search)).ToList();
        }

        private void RemoveOrder_Click(object sender, RoutedEventArgs e)
        {
            Order order = OrderLv.SelectedItem as Order;
            try
            {
                App.context.Order.Remove(order);
                App.context.SaveChanges();

                LoadData();
            }
            catch
            {
                MessageBox.Show("Выберите запись");

            }
        }

        private void EditOrder_Click(object sender, RoutedEventArgs e)
        {
            Order select = OrderLv.SelectedItem as Order;
            if (select != null)
            {
                AddEditOrderWindow addEditOrderWindow = new AddEditOrderWindow(select);
                addEditOrderWindow.ShowDialog();
                LoadData();
            }
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditOrderWindow addEditOrderWindow = new AddEditOrderWindow();

            if (addEditOrderWindow.ShowDialog() == true)
            {
                LoadData();
            }
        }
    }
}

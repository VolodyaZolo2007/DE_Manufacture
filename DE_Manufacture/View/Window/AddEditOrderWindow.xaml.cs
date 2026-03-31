using DE_Manufacture.Model;
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

namespace DE_Manufacture.View.Window
{
    /// <summary>
    /// Логика взаимодействия для AddEditOrderWindow.xaml
    /// </summary>
    public partial class AddEditOrderWindow : System.Windows.Window
    {
        private readonly Order _order;
        public AddEditOrderWindow()
        {
            InitializeComponent();

            Title = "Добавление компании";
            AddOrderBtn.Visibility = Visibility.Visible;
            EditOrderBtn.Visibility = Visibility.Collapsed;
        }

        public AddEditOrderWindow(Order select)
        {
            InitializeComponent();

            Title = "Добавление компании";
            AddOrderBtn.Visibility = Visibility.Collapsed;
            EditOrderBtn.Visibility = Visibility.Visible;
            _order = select;

            DataContext = select;
        }

        private void EditOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            App.context.SaveChanges();

            MessageBox.Show("Успешное редактирование");

            DialogResult = true;
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order()
            {
                Number = Convert.ToInt32(NumberTb.Text),
                Date = DateOrderDp.SelectedDate.Value,
                TotalPrice = Convert.ToDecimal(PriceTb.Text)
            };

            App.context.Order.Add(order);
            App.context.SaveChanges();

            MessageBox.Show("Заказ успешно добавлен");

            DialogResult = true;
        }
    }
}

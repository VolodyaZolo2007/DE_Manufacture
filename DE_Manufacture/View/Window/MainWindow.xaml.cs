using DE_Manufacture.View.Page;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CompaniesPageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CompaniesPage());
        }

        private void ManufactureBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManufacturePage());
        }

        private void OrdersPageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OrderPaGe());
        }

        private void SpecificationsPageBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Content is System.Windows.Controls.Page page)
            {
                Title = $"Главное окно - {page.Title}";
            }
        }
    }
}

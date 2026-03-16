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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DE_Manufacture.View.Page
{
    /// <summary>
    /// Логика взаимодействия для CompaniesPage.xaml
    /// </summary>
    public partial class CompaniesPage : System.Windows.Controls.Page
    {

        private List<Company> _companies;
        public CompaniesPage()
        {
            InitializeComponent();

            _companies = App.context.Company.ToList();

            CompaniewsLv.ItemsSource = _companies;
        }

        private void AddCompanyBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveCompanyBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditCompanyBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

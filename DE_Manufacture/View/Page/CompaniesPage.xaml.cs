using DE_Manufacture.Model;
using DE_Manufacture.View.Window;
using System;
using System.CodeDom;
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

           LoadData();
         
        }

        private void AddCompanyBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditWIndow addEditWIndow = new AddEditWIndow();
            if (addEditWIndow.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void RemoveCompanyBtn_Click(object sender, RoutedEventArgs e)
        {
            Company selectedCompany = (Company)CompaniewsLv.SelectedItem;

            try
            {

            if (selectedCompany != null)
            {
                App.context.Company.Remove(selectedCompany);
                App.context.SaveChanges();

                MessageBox.Show("Компания успешно удалена");
                    LoadData();
            }
            }
            catch
                {
                MessageBox.Show("Невозможно удалить компанию");
            }
        }

        private void EditCompanyBtn_Click(object sender, RoutedEventArgs e)
        {
            Company selectedCompany = (Company)CompaniewsLv.SelectedItems;
            if (selectedCompany != null)
            {

                    AddEditWIndow addEditWIndow = new AddEditWIndow(selectedCompany);
                addEditWIndow.ShowDialog();
                
                
            }
            else
            {
                MessageBox.Show("Сначала выберите компанию");
            }
        }
        public void LoadData()
        {
            _companies = App.context.Company.ToList();
            CompaniewsLv.ItemsSource= _companies;
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchString = SearchTb.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchString))
            {
                LoadData();
                return;
            }
            else
            {
                var filterList = _companies.Where(company => company.Name.ToLower().Contains(searchString) ||
                company.Insurance.ToLower().Contains(searchString)||
                company.Phone.ToLower().Contains(searchString)||
                company.Address.ToLower().Contains(searchString));
            }
        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

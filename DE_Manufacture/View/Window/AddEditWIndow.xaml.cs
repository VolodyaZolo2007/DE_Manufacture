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
    /// Логика взаимодействия для AddEditWIndow.xaml
    /// </summary>
    public partial class AddEditWIndow : System.Windows.Window
    {
        private readonly Company _currentCompany;
        //конструктор для режима "Добавить пользователя"
        public AddEditWIndow()
        {
            InitializeComponent();
            Title = "Добавление компание";
            AddCompanyBtn.Visibility = Visibility.Visible;
            EditCompanyBtn.Visibility = Visibility.Collapsed;
        }
        //конструктор для режима "Редактировать пользователя"
        public AddEditWIndow(Company selectedCompany)
        {
            InitializeComponent();

            _currentCompany = selectedCompany;
            Title = "Редактировать данные компание";
            EditCompanyBtn.Visibility = Visibility.Visible;
            AddCompanyBtn.Visibility = Visibility.Collapsed;

            DataContext = _currentCompany;
        }

        private void EditCompanyBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void AddCompanyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                Company newCompany = new Company()
                {
                    Name = NameTB.Text,
                    Insurance = InsuranceTb.Text,
                    Address = AddresTb.Text,
                    IsCustomer = IsCustomerCb.IsChecked.Value,
                    IsManufacturer = IsManufactureCb.IsChecked.Value
                };

                App.context.Company.Add(newCompany);
                App.context.SaveChanges();

            }
        }
        private bool Validate()
        {
            if (string.IsNullOrEmpty(NameTB.Text))
            {
                MessageBox.Show("Введите название компании");
                NameTB.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(InsuranceTb.Text))
            {
                MessageBox.Show("Введите ИНН");
                InsuranceTb.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(PhoneTb.Text))
            {
                MessageBox.Show("Введите номаер телефона");
                PhoneTb.Focus();
                return false;
            }
            //аа
            if (string.IsNullOrEmpty(AddresTb.Text))
            {
                MessageBox.Show("Введите адрес компании");
                AddresTb.Focus();
                return false;
            }
            if (!IsCustomerCb.IsChecked.Value && !IsManufactureCb.IsChecked.Value)
            {
                MessageBox.Show("Выберите хотя бы один пункт");
                IsCustomerCb.Focus();
                return false;
            }
            return true;
        }
    }
}

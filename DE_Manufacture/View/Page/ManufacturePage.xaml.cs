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
    /// Логика взаимодействия для ManufacturePage.xaml
    /// </summary>
    public partial class ManufacturePage : System.Windows.Controls.Page
    {
        string selectedManufacturer;

        private List<Manufacturer> _manufacturer;
        private Manufacturer selectedCompany;
        private List<string> _manufacturerTypes = new List<string>()
        {
            "Все",
            "Молоко",
            "Сливки",
            "Закваска"
        };

        public ManufacturePage()
        {
            InitializeComponent();

            LoadData();

            FilterCmb.ItemsSource = _manufacturerTypes;
            FilterCmb.SelectedIndex = 0;
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
                ManufacturerLv.ItemsSource = _manufacturer.Where(m => m.Code.ToLower().Contains(searchString) || m.productType.ToLower().Contains(searchString) || m.Material.Name.ToLower().Contains(searchString));
            }
        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedManufacturer = FilterCmb.SelectedItem.ToString();

            LoadData();
        }



        public void LoadData()
        {
            _manufacturer = App.context.Manufacturer.ToList();
            if (selectedManufacturer == "Все")
            {

                ManufacturerLv.ItemsSource = _manufacturer;
            }
            else
            {
                ManufacturerLv.ItemsSource = _manufacturer.Where(m => m.Material.Name == selectedManufacturer);
            }
        }

        private void AddManufactureBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditManufacturerWindow addEditManufacturerWindow = new AddEditManufacturerWindow();

            if (addEditManufacturerWindow.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void EditManufacture_Click(object sender, RoutedEventArgs e)
        {
            Manufacturer selectManufaacturer = (Manufacturer)ManufacturerLv.SelectedItem;
            if (selectManufaacturer != null)
            {
                AddEditManufacturerWindow editManufacturerWindow = new AddEditManufacturerWindow(selectManufaacturer);
                editManufacturerWindow.ShowDialog();
                LoadData();
            }

        }

        private void RemoveManufacture_Click(object sender, RoutedEventArgs e)
        {
            Manufacturer selectedManufacterer = ManufacturerLv.SelectedItem as Manufacturer;
            try
            {
                App.context.Manufacturer.Remove(selectedManufacterer);
                App.context.SaveChanges();

                LoadData();

            }
            catch
            {
                MessageBox.Show("Выберите запись");
            }
        }
    }
}

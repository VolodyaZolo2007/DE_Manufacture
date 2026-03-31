using DE_Manufacture.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для AddEditManufacturerWindow.xaml
    /// </summary>
    public partial class AddEditManufacturerWindow : System.Windows.Window
    {
        private readonly Manufacturer manufacturer;
        private List<Manufacturer> manufacturerList;
        private List<Material> _materiAL = new List<Material>();
        private readonly Manufacturer _manufacturer;
        public AddEditManufacturerWindow()
        {
            InitializeComponent();
            Title = "Добавление компании";
            AddManufactureBtn.Visibility = Visibility.Visible;
            EditManufactureBtn.Visibility = Visibility.Collapsed;

            NameCmb.ItemsSource = App.context.Material.ToList();
            NameCmb.DisplayMemberPath = "Name";
        }

        public AddEditManufacturerWindow(Manufacturer selectManufaacturer)
        {
            InitializeComponent();

            Title = "редактирование";

            AddManufactureBtn.Visibility = Visibility.Collapsed;
            EditManufactureBtn.Visibility = Visibility.Visible;

            manufacturer = selectManufaacturer;
            DataContext = manufacturer;

            NameCmb.ItemsSource = App.context.Material.ToList();
            NameCmb.DisplayMemberPath = "Name";
            NameCmb.SelectedValuePath = "Id";
        }

        private void EditManufactureBtn_Click(object sender, RoutedEventArgs e)
        {
            App.context.SaveChanges();

            MessageBox.Show("Данные компании успешно обновлениы");

            DialogResult = true;

        }

        private void AddManufactureBtn_Click(object sender, RoutedEventArgs e)
        {
            var selected = NameCmb.SelectedItem as Material;

            Manufacturer manufacturer = new Manufacturer
            {
                Code = CodeTb.Text,
                IsProduct = IsProductCb.IsChecked.Value,
                ItemId = selected.Id
            };

            App.context.Manufacturer.Add(manufacturer);
            App.context.SaveChanges();

            DialogResult = true;
        }
    }
}

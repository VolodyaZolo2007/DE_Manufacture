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
        public ManufacturePage()
        {
            InitializeComponent();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchString = SearchTb.Text;
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return;
            }
        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

using Newtonsoft.Json;
using SaleSystemWPF.Models;
using SaleSystemWPF.Services;
using SaleSystemWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace SaleSystemWPF.Views
{
    /// <summary>
    /// Interaction logic for ShowProductView.xaml
    /// </summary>
    public partial class ShowProductView : UserControl
    {
        private readonly ProductService productService = new ProductService();

        public ShowProductView()
        {
            InitializeComponent();

            // Get selected product to show details.
            GetProduct();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            // Yes/No confirmation box.
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to edit this product?", "Edit Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                // Navigate from this view to another view.
                MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
                mainWindow.mainContent.Content = new EditProductViewModel();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            // Yes/No confirmation box.
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to delete this product?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                // Delete current Product.
                DeleteProduct();
            }
        }

        private async void GetProduct()
        {
            // Get data from the App.Current.Properties. These work like global variables.
            int productId = int.Parse(Application.Current.Properties["productId"].ToString());

            // Function call the API to get Product and get response data.
            Product product = await productService.GetProduct(productId);

            // Assign it to the view.
            textBoxProductName.Text = product.ProductName;
            textBoxDescription.Text = product.Description;
            textBoxPrice.Text = product.Price.ToString();
            textBoxUnit.Text = product.Unit;
        }

        private async void DeleteProduct()
        {
            // Get data from the App.Current.Properties. These work like global variables.
            int productId = int.Parse(Application.Current.Properties["productId"].ToString());

            // Completing the URL and call the API to get response data.
            HttpResponseMessage response = await productService.DeleteProduct(productId);

            if (response.IsSuccessStatusCode)
            {
                // Remove productId set in App.Current.Properties.
                Application.Current.Properties["productId"] = null;

                // Navigate from this view to another view.
                MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
                mainWindow.mainContent.Content = new ProductViewModel();
            }
        }
    }
}

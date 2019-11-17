using Newtonsoft.Json;
using SaleSystemWPF.Models;
using SaleSystemWPF.Services;
using SaleSystemWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        private readonly ProductService productService = new ProductService();

        public ProductView()
        {
            InitializeComponent();

            // Get product list.
            ListProduct();
        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            // Navigate from this view to another view.
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.mainContent.Content = new AddProductViewModel();
        }

        private void HyperlinkProduct_Click(object sender, RoutedEventArgs e)
        {
            // Get Product data from the selected row in the data grid.
            Product product = (Product)((Hyperlink)e.Source).DataContext;
            int productId = product.ProductId;

            // Set productId into App.Current.Properties. This treats productId like a global variable.
            Application.Current.Properties["productId"] = productId;

            // Navigate from this view to another view.
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.mainContent.Content = new ShowProductViewModel();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            // Get Product data from the selected row in the data grid.
            Product product = (Product)((Button)e.Source).DataContext;
            int productId = product.ProductId;

            // Set productId into App.Current.Properties. This treats productId like a global variable.
            Application.Current.Properties["productId"] = productId;

            // Navigate from this view to another view.
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.mainContent.Content = new EditProductViewModel();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            // Get Product data from the selected row in the data grid.
            Product product = (Product)((Button)e.Source).DataContext;
            int productId = product.ProductId;

            // Set productId into App.Current.Properties. This treats productId like a global variable.
            Application.Current.Properties["productId"] = productId;

            // Yes/No confirmation box.
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to Delete this Product?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                // Delete the selected Product.
                DeleteProduct();
            }
        }

        private async void ListProduct()
        {
            // Get product list.
            dataGridProductList.ItemsSource = await productService.ListProduct();
        }

        private async void DeleteProduct()
        {
            // Get data from the App.Current.Properties. These work like global variables.
            int productId = int.Parse(Application.Current.Properties["productId"].ToString());

            // Completing the URL and call the API to get response data.
            HttpResponseMessage response = await productService.DeleteProduct(productId);
            
            if (response.IsSuccessStatusCode)
            {
                // Refresh the data grid.
                ListProduct();
            }
        }
    }
}

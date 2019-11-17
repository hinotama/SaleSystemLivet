using Newtonsoft.Json;
using SaleSystemWPF.Localization;
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
    /// Interaction logic for EditProductView.xaml
    /// </summary>
    public partial class EditProductView : UserControl
    {
        private readonly ProductService productService = new ProductService();

        public EditProductView()
        {
            InitializeComponent();
            GetProduct();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            EditProduct();
        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            // Yes/No confirmation box.
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to reset?", "Reset Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                // Clear all input fields.
                Reset();
            }
        }

        private void Reset()
        {
            // Clear all input fields.
            textBoxProductName.Text = "";
            textBoxDescription.Text = "";
            textBoxPrice.Text = "";
            textBoxUnit.Text = "";
            textBlockResponseMessage.Text = "";
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

        private async void EditProduct()
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to edit this product?", "Edit Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                // Get data from the App.Current.Properties. These work like global variables.
                int productId = int.Parse(Application.Current.Properties["productId"].ToString());

                // Get input data from current view.
                string productName = textBoxProductName.Text;
                string description = textBoxDescription.Text;
                float price = float.Parse(textBoxPrice.Text);
                string unit = textBoxUnit.Text;

                // Create new Product model to push it to the EditProduct function.
                Product product = new Product()
                {
                    ProductId = productId,
                    ProductName = productName,
                    Description = description,
                    Price = price,
                    Unit = unit
                };

                // Function call the API to add Product and get response data.
                var response = await productService.EditProduct(product);
                var responseData = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    // Remove the productId set in App.Current.Properties.
                    Application.Current.Properties["productId"] = null;

                    // Navigate from this view to another view.
                    MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
                    mainWindow.mainContent.Content = new ProductViewModel();
                }
                else
                {
                    // Change response message text to Red.
                    textBlockResponseMessage.Foreground = Brushes.Red;
                }

                // Show the response message from the server.
                textBlockResponseMessage.Text = responseData;
            }
        }
    }
}

using Newtonsoft.Json;
using SaleSystemWPF.Localization;
using SaleSystemWPF.Models;
using SaleSystemWPF.Services;
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
    /// Interaction logic for AddProductView.xaml
    /// </summary>
    public partial class AddProductView : UserControl
    {
        private readonly ProductService productService = new ProductService();

        public AddProductView()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            AddProduct();
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

        private async void AddProduct()
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to add this product?", "Save Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                // Get input data from current view.
                string productName = textBoxProductName.Text;
                string description = textBoxDescription.Text;
                float price = float.Parse(textBoxPrice.Text);
                string unit = textBoxUnit.Text;

                // Create new Product model to push it to the AddProduct function.
                Product product = new Product()
                {
                    ProductName = productName,
                    Description = description,
                    Price = price,
                    Unit = unit
                };

                // Function call the API to add Product and get response data.
                var response = await productService.AddProduct(product);
                var responseData = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    // Clear all input fields.
                    Reset();

                    // Change response message text to Green.
                    textBlockResponseMessage.Foreground = Brushes.Green;
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

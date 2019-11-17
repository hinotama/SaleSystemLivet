using Newtonsoft.Json;
using SaleSystemWPF.Localization;
using SaleSystemWPF.Models;
using SaleSystemWPF.Services;
using SaleSystemWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        private readonly OrderService orderService = new OrderService();
        private readonly ProductService productService = new ProductService();

        public ObservableCollection<Order> orderList { get; set; }
        public List<Product> productList { get; set; }

        public OrderView()
        {
            InitializeComponent();
            SetupOrderDataGrid();
        }

        private void ButtonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            // Create 1 new row of order list.
            orderList.Add(new Order());

            // Set data grid's data.
            DataContext = this;
        }

        private void ButtonSubmitOrder_Click(object sender, RoutedEventArgs e)
        {
            AddOrderList();
        }

        private void ButtonViewOrderHistory_Click(object sender, RoutedEventArgs e)
        {
            // Navigate from this view to another view.
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.mainContent.Content = new OrderHistoryViewModel();
        }

        private async void SetupOrderDataGrid()
        {
            // Create 1 new row of order list.
            orderList = new ObservableCollection<Order>
            {
                new Order()
            };

            // Get product list data from the database.
            productList = await productService.ListProduct();

            // Set data grid's data.
            DataContext = this;
        }

        private async void AddOrderList()
        {
            // Yes/No confirmation box.
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to submit these orders?", "Submit Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                // Get current user id from App.Current.Properties.
                int userId = int.Parse(Application.Current.Properties["userId"].ToString());

                // Create new dummy list to store data.
                List<Order> submitOrderList = new List<Order>();
                foreach (Order row in dataGridOrderList.Items.OfType<Order>())
                {
                    // Check if user input quantity or not.
                    if (row.Quantity == 0 || row.Quantity == null)
                    {
                        MessageBox.Show("Please enter quantity you want to order.", "Error Message");
                        return;
                    }
                    row.UserId = userId;
                    submitOrderList.Add(row);
                }

                // Function call the API to add Product and get response data.
                HttpResponseMessage response = await orderService.AddOrderList(submitOrderList);
                var responseData = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    // Navigate from this view to another view.
                    MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
                    mainWindow.mainContent.Content = new OrderHistoryViewModel();
                }
            }
        }
    }
}

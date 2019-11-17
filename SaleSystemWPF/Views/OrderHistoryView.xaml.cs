using Newtonsoft.Json;
using SaleSystemWPF.Localization;
using SaleSystemWPF.Models;
using SaleSystemWPF.Services;
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
    /// Interaction logic for OrderHistoryView.xaml
    /// </summary>
    public partial class OrderHistoryView : UserControl
    {
        private readonly OrderService orderService = new OrderService();

        public OrderHistoryView()
        {
            InitializeComponent();
            ListOrder();
        }

        private async void ListOrder()
        {
            // Function call the API to get Order list.
            List<Order> orderList = await orderService.ListOrder();
            List<OrderHistory> orderHistoryList = new List<OrderHistory>();
            foreach (Order order in orderList)
            {
                orderHistoryList.Add(new OrderHistory()
                {
                    OrderId = order.OrderId,
                    ProductName = order.Product.ProductName,
                    Description = order.Product.Description,
                    Unit = order.Product.Unit,
                    Price = order.Product.Price,
                    Quantity = order.Quantity,
                    TotalPrice = order.Product.Price * order.Quantity
                });
            }
            dataGridOrderList.ItemsSource = orderHistoryList;
        }
    }

    internal class OrderHistory
    {
        public int? OrderId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public double? TotalPrice { get; set; }
    }
}

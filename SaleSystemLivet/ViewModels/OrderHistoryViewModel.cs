using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using SaleSystemLivet.Models;
using SaleSystemLivet.Services;
using System.Collections.ObjectModel;

namespace SaleSystemLivet.ViewModels
{
    public class OrderHistoryViewModel : ViewModel
    {
        // Some useful code snippets for ViewModel are defined as l*(llcom, llcomn, lvcomm, lsprop, etc...).

        #region Parameter declaration
        // View Model parameters
        private List<OrderHistoryModel> _OrderList;

        // Other parameters
        private readonly OrderService _OrderService;
        private readonly ProductService _ProductService;
        #endregion Parameter declaration

        #region Parameter definition
        public List<OrderHistoryModel> OrderList
        {
            get
            {
                return _OrderList;
            }
            set
            {
                if (_OrderList != value)
                {
                    _OrderList = value;
                    RaisePropertyChanged("OrderList");
                }
            }
        }

        public int? AllQuantity { get; set; }
        public decimal? AllPrice { get; set; }
        #endregion Parameter definition

        #region Constructor
        public OrderHistoryViewModel()
        {
            _OrderList = new List<OrderHistoryModel>();
            _OrderService = new OrderService();
            _ProductService = new ProductService();

            AllQuantity = 0;
            AllPrice = 0;

            ListOrderHistory();
        }
        #endregion Constructor

        #region Private functions
        private void ListOrderHistory()
        {
            // Function call the API to get Order list.
            List<Order> orderList = _OrderService.ListOrder();
            OrderList = new List<OrderHistoryModel>();
            foreach (Order order in orderList)
            {
                OrderList.Add(new OrderHistoryModel()
                {
                    OrderId = order.OrderId,
                    ProductName = order.Product.ProductName,
                    Description = order.Product.Description,
                    Unit = order.Product.Unit,
                    Price = order.Product.Price,
                    Quantity = order.Quantity,
                    TotalPrice = order.Product.Price * order.Quantity
                });
                AllQuantity += order.Quantity;
                AllPrice += order.Product.Price * order.Quantity;
            }
        }
        #endregion

        public class OrderHistoryModel
        {
            public int OrderId { get; set; }
            public string ProductName { get; set; }
            public string Description { get; set; }
            public string Unit { get; set; }
            public decimal? Price { get; set; }
            public int? Quantity { get; set; }
            public decimal? TotalPrice { get; set; }
        }

        // This method would be called from View, when ContentRendered event was raised.
        //public void Initialize()
        //{
        //}
    }
}

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
using System.Net.Http;
using System.Windows;
using System.Collections.ObjectModel;

namespace SaleSystemLivet.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        // Some useful code snippets for ViewModel are defined as l*(llcom, llcomn, lvcomm, lsprop, etc...).

        #region Parameter declaration
        // View Model parameters
        public ObservableCollection<OrderModel> _OrderList;
        public static List<Product> _ProductList;
        public static int? _AllQuantity;
        public static decimal? _AllPrice;

        // Other parameters
        private readonly OrderService _OrderService;
        private readonly ProductService _ProductService;
        #endregion Parameter declaration

        #region Parameter definition
        public ObservableCollection<OrderModel> OrderList
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
        
        public List<Product> ProductList
        {
            get
            {
                return _ProductList;
            }
            set
            {
                if (_ProductList != value)
                {
                    _ProductList = value;
                    RaisePropertyChanged("ProductList");
                }
            }
        }

        public int? AllQuantity
        {
            get
            {
                return _AllQuantity;
            }
            set
            {
                if (_AllQuantity != value)
                {
                    _AllQuantity = value;
                    RaisePropertyChanged("AllQuantity");
                }
            }
        }

        public decimal? AllPrice
        {
            get
            {
                return _AllPrice;
            }
            set
            {
                if (_AllPrice != value)
                {
                    _AllPrice = value;
                    RaisePropertyChanged("AllPrice");
                }
            }
        }
        #endregion Parameter definition

        #region Constructor
        public OrderViewModel()
        {
            _OrderService = new OrderService();
            _ProductService = new ProductService();

            AllQuantity = 0;
            AllPrice = 0;

            SetupOrderDataGrid();
        }
        #endregion Constructor

        #region AddOrderCommand
        private ViewModelCommand _AddOrderCommand;

        public ViewModelCommand AddOrderCommand
        {
            get
            {
                if (_AddOrderCommand == null)
                {
                    _AddOrderCommand = new ViewModelCommand(AddOrder);
                }
                return _AddOrderCommand;
            }
        }

        public void AddOrder()
        {
            // Create 1 new row of order list.
            OrderList.Add(new OrderModel());
        }
        #endregion AddOrderCommand

        #region SubmitOrderCommand
        private ViewModelCommand _SubmitOrderCommand;

        public ViewModelCommand SubmitOrderCommand
        {
            get
            {
                if (_SubmitOrderCommand == null)
                {
                    _SubmitOrderCommand = new ViewModelCommand(SubmitOrder);
                }
                return _SubmitOrderCommand;
            }
        }
        #endregion SubmitOrderCommand

        #region Private functions
        private void SetupOrderDataGrid()
        {
            // Create 1 new row of order list.
            OrderList = new ObservableCollection<OrderModel>
            {
                new OrderModel()
            };

            // Get product list data from the database.
            ProductList = _ProductService.GetProducts();
        }

        public void SubmitOrder()
        {
            if (ConfirmDialog("Are you sure you want to submit these orders?", "Submit Confirmation"))
            {
                // Get current user id from App.Current.Properties.
                //int userId = int.Parse(Application.Current.Properties["userId"].ToString());
                int userId = 1;

                // Create new dummy list to store data.
                List<Order> submitOrderList = new List<Order>();
                Order submitOrder;
                foreach (OrderModel order in _OrderList)
                {
                    submitOrder = new Order();

                    // Check if user input quantity or not.
                    if (order.Quantity == 0 || order.Quantity == null)
                    {
                        MessageBox.Show("Please enter quantity you want to order.", "Error Message");
                        return;
                    }

                    submitOrder.Quantity = order.Quantity;
                    submitOrder.ProductId = order.ProductId;
                    submitOrder.UserId = userId;

                    submitOrderList.Add(submitOrder);
                }

                // Function call the API to add Product and get response data.
                HttpResponseMessage response = _OrderService.AddOrderList(submitOrderList);
                var responseData = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    // Navigate to Order History view.

                }
            }
        }

        protected bool ConfirmDialog(String text, String title)
        {
            var message = new ConfirmationMessage(text, title, MessageBoxImage.Question, MessageBoxButton.YesNo, "Confirm");
            Messenger.Raise(message);
            return message.Response.Value;
        }
        #endregion Private functions

        #region Event methods
        public void CalculateGridTotal()
        {
            AllQuantity = 0;
            AllPrice = 0;
            foreach (OrderModel order in OrderList)
            {
                AllQuantity += (order.Quantity == null ? 0 : order.Quantity);
                AllPrice += (order.TotalPrice == null ? 0 : order.TotalPrice);
            }
        }
        #endregion Event methods

        public class OrderModel : NotificationObject
        {
            int _ProductId;
            string _Description;
            string _Unit;
            decimal? _Price;
            int? _Quantity;
            decimal? _TotalPrice;

            public int ProductId
            {
                get
                {
                    return _ProductId;
                }
                set
                {
                    if (_ProductId != value)
                    {
                        _ProductId = value;
                        RaisePropertyChanged("ProductId");
                        RefreshData(_ProductId);
                        CalculateTotalPrice(_Price, _Quantity);
                    }
                }
            }

            public string Description
            {
                get
                {
                    return _Description;
                }
                set
                {
                    if (_Description != value)
                    {
                        _Description = value;
                        RaisePropertyChanged("Description");
                    }
                }
            }

            public string Unit
            {
                get
                {
                    return _Unit;
                }
                set
                {
                    if (_Unit != value)
                    {
                        _Unit = value;
                        RaisePropertyChanged("Unit");
                    }
                }
            }

            public decimal? Price
            {
                get
                {
                    return _Price;
                }
                set
                {
                    if (_Price != value)
                    {
                        _Price = value;
                        RaisePropertyChanged("Price");
                    }
                }
            }

            public int? Quantity
            {
                get
                {
                    return _Quantity;
                }
                set
                {
                    if (_Quantity != value)
                    {
                        _Quantity = value;
                        RaisePropertyChanged("Quantity");
                        CalculateTotalPrice(_Price, _Quantity);
                    }
                }
            }

            public decimal? TotalPrice
            {
                get
                {
                    return _TotalPrice;
                }
                set
                {
                    if (_TotalPrice != value)
                    {
                        _TotalPrice = value;
                        RaisePropertyChanged("TotalPrice");
                    }
                }
            }

            private void RefreshData(int _ProductId)
            {
                Product product = _ProductList.Find(p => p.ProductId == _ProductId);
                Description = (product == null ? "" : product.Description);
                Unit = (product == null ? "" : product.Unit);
                Price = (product == null ? 0 : product.Price);
            }

            private void CalculateTotalPrice(decimal? _Price, int? _Quantity)
            {
                TotalPrice = _Price * _Quantity;
            }
        }

        // This method would be called from View, when ContentRendered event was raised.
        //public void Initialize()
        //{
        //}
    }
}

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

namespace SaleSystemLivet.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region Parameter declaration
        // View Model parameters
        private object _ViewModel;
        
        // Other parameters

        #endregion Parameter declaration

        #region Parameter definition
        public object ViewModel
        {
            get
            {
                return _ViewModel;
            }
            set
            {
                if (_ViewModel != value)
                {
                    _ViewModel = value;
                    RaisePropertyChanged("ViewModel");
                }
            }
        }
        #endregion Parameter definition

        #region Constructor
        public MainWindowViewModel()
        {
            NavigateTo("Index");
        }
        #endregion Constructor

        #region ShowIndexCommand
        private ViewModelCommand _ShowIndexCommand;

        public ViewModelCommand ShowIndexCommand
        {
            get
            {
                if (_ShowIndexCommand == null)
                {
                    _ShowIndexCommand = new ViewModelCommand(ShowIndexView);
                }
                return _ShowIndexCommand;
            }
        }

        public void ShowIndexView()
        {
            NavigateTo("Index");
        }
        #endregion ShowIndexCommand

        #region ShowProductCommand
        private ViewModelCommand _ShowProductCommand;

        public ViewModelCommand ShowProductCommand
        {
            get
            {
                if (_ShowProductCommand == null)
                {
                    _ShowProductCommand = new ViewModelCommand(ShowProductView);
                }
                return _ShowProductCommand;
            }
        }

        public void ShowProductView()
        {
            NavigateTo("Product");
        }
        #endregion ShowProductCommand

        #region ShowOrderCommand
        private ViewModelCommand _ShowOrderCommand;

        public ViewModelCommand ShowOrderCommand
        {
            get
            {
                if (_ShowOrderCommand == null)
                {
                    _ShowOrderCommand = new ViewModelCommand(ShowOrderView);
                }
                return _ShowOrderCommand;
            }
        }

        public void ShowOrderView()
        {
            NavigateTo("Order");
        }
        #endregion ShowOrderCommand

        #region ShowAboutCommand
        private ViewModelCommand _ShowAboutCommand;

        public ViewModelCommand ShowAboutCommand
        {
            get
            {
                if (_ShowAboutCommand == null)
                {
                    _ShowAboutCommand = new ViewModelCommand(ShowAboutView);
                }
                return _ShowAboutCommand;
            }
        }

        public void ShowAboutView()
        {
            NavigateTo("About");
        }
        #endregion ShowAboutCommand

        #region ShowAddProductCommand
        private ViewModelCommand _ShowAddProductCommand;

        public ViewModelCommand ShowAddProductCommand
        {
            get
            {
                if (_ShowAddProductCommand == null)
                {
                    _ShowAddProductCommand = new ViewModelCommand(ShowAddProductView);
                }
                return _ShowAddProductCommand;
            }
        }

        public void ShowAddProductView()
        {
            NavigateTo("AddProduct");
        }
        #endregion ShowAddProductCommand

        #region ShowEditProductCommand
        private ListenerCommand<int> _ShowEditProductCommand;

        public ListenerCommand<int> ShowEditProductCommand
        {
            get
            {
                if (_ShowEditProductCommand == null)
                {
                    _ShowEditProductCommand = new ListenerCommand<int>(ShowEditProductView);
                }
                return _ShowEditProductCommand;
            }
        }

        public void ShowEditProductView(int productId)
        {
            App.Current.Properties["productId"] = productId;
            NavigateTo("EditProduct");
        }
        #endregion ShowEditProductCommand

        #region ShowProductDetailCommand
        private ListenerCommand<int> _ShowProductDetailCommand;

        public ListenerCommand<int> ShowProductDetailCommand
        {
            get
            {
                if (_ShowProductDetailCommand == null)
                {
                    _ShowProductDetailCommand = new ListenerCommand<int>(ShowProductDetailView);
                }
                return _ShowProductDetailCommand;
            }
        }

        public void ShowProductDetailView(int productId)
        {
            App.Current.Properties["productId"] = productId;
            NavigateTo("ProductDetail");
        }
        #endregion ShowProductDetailCommand

        #region ShowOrderHistoryCommand
        private ViewModelCommand _ShowOrderHistoryCommand;

        public ViewModelCommand ShowOrderHistoryCommand
        {
            get
            {
                if (_ShowOrderHistoryCommand == null)
                {
                    _ShowOrderHistoryCommand = new ViewModelCommand(ShowOrderHistoryView);
                }
                return _ShowOrderHistoryCommand;
            }
        }

        public void ShowOrderHistoryView()
        {
            NavigateTo("OrderHistory");
        }
        #endregion ShowOrderHistoryCommand

        #region Private functions
        private void NavigateTo(string destination)
        {
            if (destination.Equals("Index"))
            {
                _ViewModel = new IndexViewModel();
            }
            else if (destination.Equals("Product"))
            {
                _ViewModel = new ProductViewModel();
            }
            else if (destination.Equals("Order"))
            {
                _ViewModel = new OrderViewModel();
            }
            else if (destination.Equals("About"))
            {
                _ViewModel = new AboutViewModel();
            }
            else if (destination.Equals("AddProduct"))
            {
                _ViewModel = new AddProductViewModel();
            }
            else if (destination.Equals("EditProduct"))
            {
                _ViewModel = new EditProductViewModel();
            }
            else if (destination.Equals("ProductDetail"))
            {
                _ViewModel = new ProductDetailViewModel();
            }
            else if (destination.Equals("OrderHistory"))
            {
                _ViewModel = new OrderHistoryViewModel();
            }
            RaisePropertyChanged("ViewModel");
        }
        #endregion Private functions

        // Some useful code snippets for ViewModel are defined as l*(llcom, llcomn, lvcomm, lsprop, etc...).
        //public void Initialize()
        //{
        //    ShowIndexView();
        //}
    }
}

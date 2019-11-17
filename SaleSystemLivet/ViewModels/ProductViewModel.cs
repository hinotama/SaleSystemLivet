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
using System.Windows.Media;
using System.Windows;

namespace SaleSystemLivet.ViewModels
{
    public class ProductViewModel : ViewModel
    {
        // Some useful code snippets for ViewModel are defined as l*(llcom, llcomn, lvcomm, lsprop, etc...).

        #region Parameter declaration
        // View Model parameters
        private List<Product> _ProductList;

        // Other parameters
        private readonly ProductService _ProductService;

        private string _PreviousButton;
        private string _NextButton;
        private int _CurrentPage;

        private readonly int pageSize;
        private int totalCount;
        #endregion Parameter declaration

        #region Parameter definition
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

        public string PreviousButton
        {
            get
            {
                return _PreviousButton;
            }
            set
            {
                if (_PreviousButton != value)
                {
                    _PreviousButton = value;
                    RaisePropertyChanged("PreviousButton");
                }
            }
        }

        public string NextButton
        {
            get
            {
                return _NextButton;
            }
            set
            {
                if (_NextButton != value)
                {
                    _NextButton = value;
                    RaisePropertyChanged("NextButton");
                }
            }
        }

        public int CurrentPage
        {
            get
            {
                return _CurrentPage;
            }
            set
            {
                if (_CurrentPage != value)
                {
                    _CurrentPage = value;
                    if (_CurrentPage == 1)
                    {
                        PreviousButton = "False";
                    }
                    else
                    {
                        PreviousButton = "True";
                    }
                    RaisePropertyChanged("CurrentPage");
                }
            }
        }
        #endregion Parameter definition

        #region Constructor
        public ProductViewModel()
        {
            _ProductService = new ProductService();

            PreviousButton = "False";
            NextButton = "True";
            CurrentPage = 1;

            pageSize = 13;
            totalCount = _ProductService.GetProducts().Count;

            GetProducts();
        }
        #endregion Constructor

        #region DeleteProductCommand
        private ListenerCommand<int> _DeleteProductCommand;

        public ListenerCommand<int> DeleteProductCommand
        {
            get
            {
                if (_DeleteProductCommand == null)
                {
                    _DeleteProductCommand = new ListenerCommand<int>(DeleteProduct);
                }
                return _DeleteProductCommand;
            }
        }
        #endregion DeleteProductCommand

        #region Private functions
        private void GetProducts()
        {
            // Get product list.
            var products = _ProductService.GetProducts(pageSize, _CurrentPage);
            if (pageSize * _CurrentPage >= totalCount)
            {
                NextButton = "False";
            }
            else
            {
                NextButton = "True";
            }
            ProductList = products;
        }

        private void DeleteProduct(int productId)
        {
            if (ConfirmDialog("Are you sure you want to delete this product?", "Delete Confirmation"))
            {
                // Completing the URL and call the API to get response data.
                HttpResponseMessage response = _ProductService.DeleteProduct(productId);

                if (response.IsSuccessStatusCode)
                {
                    // Refresh the data grid.
                    GetProducts();
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
        public void PreviousPage()
        {
            CurrentPage--;
            GetProducts();
        }
        public void NextPage()
        {
            CurrentPage++;
            GetProducts();
        }
        #endregion Event methods

        // This method would be called from View, when ContentRendered event was raised.
        //public void Initialize()
        //{
        //}
    }
}

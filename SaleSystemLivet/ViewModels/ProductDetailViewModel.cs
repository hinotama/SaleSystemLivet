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

namespace SaleSystemLivet.ViewModels
{
    public class ProductDetailViewModel : ViewModel
    {
        // Some useful code snippets for ViewModel are defined as l*(llcom, llcomn, lvcomm, lsprop, etc...).

        #region Parameter declaration
        // View Model parameters
        private Product _Product;

        // Other parameters
        private readonly ProductService _ProductService;
        #endregion Parameter declaration

        #region Constructor
        public ProductDetailViewModel()
        {
            _ProductService = new ProductService();

            GetProduct();
        }
        #endregion Constructor

        #region Parameter definition
        public Product Product
        {
            get
            {
                return _Product;
            }
            set
            {
                if (_Product != value)
                {
                    _Product = value;
                    RaisePropertyChanged("Product");
                }
            }
        }
        #endregion Parameter definition

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
        private void GetProduct()
        {
            int productId = int.Parse(App.Current.Properties["productId"].ToString());
            
            // Get product by productId.
            Product = _ProductService.GetProduct(productId);
        }

        private void DeleteProduct(int productId)
        {
            if (ConfirmDialog("Are you sure you want to delete this product?", "Delete Confirmation"))
            {
                // Completing the URL and call the API to get response data.
                HttpResponseMessage response = _ProductService.DeleteProduct(productId);

                if (response.IsSuccessStatusCode)
                {
                    // Navigate to Product view.
                    
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

        // This method would be called from View, when ContentRendered event was raised.
        //public void Initialize()
        //{
        //}
    }
}

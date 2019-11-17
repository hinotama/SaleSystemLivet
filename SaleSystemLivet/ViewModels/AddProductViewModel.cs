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
using System.Windows;
using System.Windows.Media;

namespace SaleSystemLivet.ViewModels
{
    public class AddProductViewModel : ViewModel
    {
        // Some useful code snippets for ViewModel are defined as l*(llcom, llcomn, lvcomm, lsprop, etc...).

        #region Parameter declaration
        // View Model parameters
        private Product _Product;
        private string _ResponseTextBlock;
        private Brush _ForegroundTextBlock;

        // Other parameters
        private readonly ProductService _ProductService;
        #endregion Parameter declaration

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

        public string ResponseTextBlock
        {
            get
            {
                return _ResponseTextBlock;
            }
            set
            {
                if (_ResponseTextBlock != value)
                {
                    _ResponseTextBlock = value;
                    RaisePropertyChanged("ResponseTextBlock");
                }
            }
        }

        public Brush ForegroundTextBlock
        {
            get
            {
                return _ForegroundTextBlock;
            }
            set
            {
                if (_ForegroundTextBlock != value)
                {
                    _ForegroundTextBlock = value;
                    RaisePropertyChanged("ForegroundTextBlock");
                }
            }
        }
        #endregion Parameter definition

        #region Constructor
        public AddProductViewModel()
        {
            _ProductService = new ProductService();
            Product = new Product();
        }
        #endregion Constructor

        #region AddProductCommand
        private ViewModelCommand _AddProductCommand;

        public ViewModelCommand AddProductCommand
        {
            get
            {
                if (_AddProductCommand == null)
                {
                    _AddProductCommand = new ViewModelCommand(AddProduct);
                }
                return _AddProductCommand;
            }
        }
        #endregion AddProductCommand

        #region ResetProductCommand
        private ViewModelCommand _ResetProductCommand;

        public ViewModelCommand ResetProductCommand
        {
            get
            {
                if (_ResetProductCommand == null)
                {
                    _ResetProductCommand = new ViewModelCommand(ResetProduct);
                }
                return _ResetProductCommand;
            }
        }
        #endregion ResetProductCommand

        #region Private functions
        private void AddProduct()
        {
            if (ConfirmDialog("Are you sure you want to add this product?", "Save Confirmation"))
            {
                if (ValidateProduct())
                {
                    // Function call the API to add Product and get response data.
                    var response = _ProductService.AddProduct(Product);
                    var responseData = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // Clear all input fields.
                        ResetProduct();

                        // Change response message text to Green.
                        ForegroundTextBlock = new SolidColorBrush(Colors.Green);
                    }
                    else
                    {
                        // Change response message text to Red.
                        ForegroundTextBlock = new SolidColorBrush(Colors.Red);
                    }

                    // Show the response message from the server.
                    ResponseTextBlock = responseData;
                }
            }
        }

        private void ResetProduct()
        {
            // Clear all input fields.
            Product = new Product();
        }

        private bool ValidateProduct()
        {
            ResponseTextBlock = "Please fix this/these below error(s):\n";
            bool errorFlag = false;

            if (Product.ProductName == null || Product.ProductName == "")
            {
                ResponseTextBlock += "- Product Name is required\n";
                errorFlag = true;
            }
            else if (Product.ProductName.Length > 20)
            {
                ResponseTextBlock += "- Product Name must not longer than 20 characters\n";
                errorFlag = true;
            }
            if (Product.Description == null || Product.Description == "")
            {
                ResponseTextBlock += "- Description is required\n";
                errorFlag = true;
            }
            if (Product.Unit == null || Product.Unit == "")
            {
                ResponseTextBlock += "- Unit is required\n";
                errorFlag = true;
            }
            else if (Product.Unit.Length > 10)
            {
                ResponseTextBlock += "- Unit must not longer than 10 characters\n";
                errorFlag = true;
            }
            if (Product.Price == null)
            {
                ResponseTextBlock += "- Price is required\n";
                errorFlag = true;
            }

            if (errorFlag)
            {
                ForegroundTextBlock = new SolidColorBrush(Colors.Red);
            }
            else
            {
                ForegroundTextBlock = new SolidColorBrush(Colors.Green);
            }

            return !errorFlag;
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

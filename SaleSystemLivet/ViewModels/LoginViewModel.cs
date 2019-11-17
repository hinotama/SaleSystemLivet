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
using Newtonsoft.Json;
using System.Windows;

namespace SaleSystemLivet.ViewModels
{
    public class LoginViewModel : ViewModel
    {
        // Some useful code snippets for ViewModel are defined as l*(llcom, llcomn, lvcomm, lsprop, etc...).

        #region Parameter declaration
        // View Model parameters
        private string _Username;
        private string _Password;
        private string _ErrorMessage;

        // Other parameters
        private readonly AuthService _AuthService;
        #endregion Parameter declaration

        #region Parameter definition
        public string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                if (_Username != value)
                {
                    _Username = value;
                    RaisePropertyChanged("Username");
                }
            }
        }
        
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    RaisePropertyChanged("Password");
                }
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }
            set
            {
                if (_ErrorMessage != value)
                {
                    _ErrorMessage = value;
                    RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        #endregion Parameter definition

        #region Constructor
        public LoginViewModel()
        {
            _AuthService = new AuthService();
        }
        #endregion Constructor

        #region LoginCommand
        private ViewModelCommand _LoginCommand;

        public ViewModelCommand LoginCommand
        {
            get
            {
                if (_LoginCommand == null)
                {
                    _LoginCommand = new ViewModelCommand(Login);
                }
                return _LoginCommand;
            }
        }

        private void Login()
        {
            // Completing the URL and call the API to get response data.
            HttpResponseMessage response = _AuthService.Login(Username, Password);
            string responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response data.
                var data = JsonConvert.DeserializeObject<Auth>(responseData);

                // Set token data and username to App.Current.Properties. These work like global variables.
                Application.Current.Properties["token"] = data.Token;
                Application.Current.Properties["userId"] = data.UserId;
                Application.Current.Properties["username"] = Username;

                // Show the Main Window.
                Messenger.Raise(new TransitionMessage(new MainWindowViewModel(), "ShowMainWindow"));

                // Close the Login Window.
                Messenger.Raise(new WindowActionMessage(WindowAction.Close, "CloseLoginWindow"));
            }
            else
            {
                ErrorMessage = responseData;
            }
        }
        #endregion LoginCommand

        // This method would be called from View, when ContentRendered event was raised.
        //public void Initialize()
        //{
        //}
    }
}

using Newtonsoft.Json;
using SaleSystemWPF.Models;
using SaleSystemWPF.Services;
using SaleSystemWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SaleSystemWPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly AuthService authService = new AuthService();

        public Login()
        {
            InitializeComponent();
        }

        private void HyperlinkRegister_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implement yet!", "Error Message");
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            StartLogin();
        }

        private void TextBoxLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                StartLogin();
            }
        }

        private async void StartLogin()
        {
            // Get input data.
            string username = textBoxUsername.Text;
            string password = passwordBoxLogin.Password;

            // Completing the URL and call the API to get response data.
            HttpResponseMessage response = await authService.Login(username, password);
            string responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response data.
                var data = JsonConvert.DeserializeObject<Auth>(responseData);

                // Set token data and username to App.Current.Properties. These work like global variables.
                Application.Current.Properties["token"] = data.Token;
                Application.Current.Properties["userId"] = data.UserId;
                Application.Current.Properties["username"] = username;

                // Show the Main Window.
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                // Close the Login Window.
                Close();
            }
            else
            {
                errorMessage.Text = responseData;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for IndexView.xaml
    /// </summary>
    public partial class IndexView : UserControl
    {
        public IndexView()
        {
            InitializeComponent();

            // Get username from App.Current.Properties to show.
            labelUsername.Content = Application.Current.Properties["username"].ToString();
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            // Yes/No confirmation box.
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                // Remove token and username from App.Current.Properties.
                Application.Current.Properties["token"] = null;
                Application.Current.Properties["username"] = null;

                // Show Login Window.
                Login login = new Login();
                login.Show();

                // Close this Main Window.
                MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
                mainWindow.Close();
            }
        }

        private void ComboBoxLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int language = comboBoxLanguage.SelectedIndex;
            if (language == 1)
            {
                SetLanguage("en-US");
            }
            else if (language == 2)
            {
                SetLanguage("ja-JP");
            }
        }

        private static void SetLanguage(string locale)
        {
            if (string.IsNullOrEmpty(locale)) locale = "en-US";
            Localization.TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo(locale);
        }
    }
}

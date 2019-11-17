using SaleSystemWPF.ViewModels;
using SaleSystemWPF.Views;
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

namespace SaleSystemWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainContent.Content = new IndexViewModel();
        }

        private void IndexView_Clicked(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new IndexViewModel();
        }

        private void ProductView_Clicked(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new ProductViewModel();
        }

        private void OrderView_Clicked(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new OrderViewModel();
        }
        
        private void AboutView_Clicked(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new AboutViewModel();
        }
    }
}

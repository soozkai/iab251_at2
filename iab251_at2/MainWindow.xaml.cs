using System.Windows;
using System.Windows.Controls;

namespace iab251_at2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Navigate to Customer Registration page
        private void RegisterCustomer_Click(object sender, RoutedEventArgs e)
        {
            MainOptionsContainer.Visibility = Visibility.Collapsed;
            MainFrame.Visibility = Visibility.Visible;
            MainFrame.Navigate(new CustomerRegistration());  
        }

        // Navigate to Employee Registration page
        private void RegisterEmployee_Click(object sender, RoutedEventArgs e)
        {
            MainOptionsContainer.Visibility = Visibility.Collapsed;
            MainFrame.Visibility = Visibility.Visible;
            MainFrame.Navigate(new EmployeeRegistration());  
        }

        // Navigate to Login page
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            MainOptionsContainer.Visibility = Visibility.Collapsed;
            MainFrame.Visibility = Visibility.Visible;
            MainFrame.Navigate(new Login());  
        }

      
        public void ShowMainOptions()
        {
            MainOptionsContainer.Visibility = Visibility.Visible;
            MainFrame.Visibility = Visibility.Collapsed;
        }
    }
}

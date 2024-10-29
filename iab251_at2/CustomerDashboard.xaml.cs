using System.Windows;
using System.Windows.Controls;

namespace iab251_at2
{
    public partial class CustomerDashboard : Page
    {
        public CustomerDashboard()
        {
            InitializeComponent();
        }

        // Method to handle viewing quotations
        private void ViewQuotations_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CustomerQuotationOverview());
        }

        // Method to handle profile access
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            // Logic to display profile
            MessageBox.Show("Accessing Profile");
        }

        // Method to handle logging out
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            // Logic to log out the user
            MessageBox.Show("Logging out");

            // Navigate back to the login page or main page
            NavigationService?.Navigate(new Login()); 
        }
    }
}

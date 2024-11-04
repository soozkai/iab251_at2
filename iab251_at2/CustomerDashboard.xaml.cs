using System.Windows;
using System.Windows.Controls;
using iab251_at2.Services;

namespace iab251_at2
{
    public partial class CustomerDashboard : Page
    {
        public CustomerDashboard()
        {
            InitializeComponent();
            ShowNotifications(); // Check and show notifications on load
            RequestQuotationButton.IsEnabled = false; // Disable initially until login enables it
        }

        // Method to enable the "Request Quotation" feature after login
        public void EnableRequestQuotation()
        {
            RequestQuotationButton.IsEnabled = true; // Assumes a button named RequestQuotationButton in XAML
        }

        // Click event for the "Request Quotation" button
        private void RequestQuotation_Click(object sender, RoutedEventArgs e)
        {
            if (RequestQuotationButton.IsEnabled)
            {
                NavigationService?.Navigate(new RequestQuotationPage()); // Navigate to the Request Quotation page
            }
            else
            {
                MessageBox.Show("You must be logged in to request a quotation.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Method to handle viewing quotations
        private void ViewQuotations_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CustomerQuotationOverview());
        }

        // Method to handle profile access
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Accessing Profile");
        }

        // Method to handle logging out
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logging out");
            NavigationService?.Navigate(new Login());
        }

        // Method to display notifications
        private void ShowNotifications()
        {
            var notifications = NotificationService.GetUnreadNotifications();
            foreach (var notification in notifications)
            {
                MessageBox.Show(notification.Message, "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                notification.IsRead = true;
            }
        }
    }
}

using System.Windows;
using System.Windows.Controls;
using iab251_at2.Models;
using iab251_at2.Services;

namespace iab251_at2
{
    /// <summary>
    /// Represents the dashboard for customers, allowing them to manage their quotations and account settings.
    /// </summary>
    public partial class CustomerDashboard : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDashboard"/> class.
        /// Displays notifications upon loading and initializes the request quotation button.
        /// </summary>
        public CustomerDashboard()
        {
            InitializeComponent();
            ShowNotifications(); // Check and show notifications on load
            QuotationOverviewButton.IsEnabled = false; // Disable initially until login enables it
        }

        /// <summary>
        /// Enables the "Request Quotation" feature after the user has logged in.
        /// </summary>
        public void EnableRequestQuotation()
        {
            RequestQuotationButton.IsEnabled = true; // Assumes a button named RequestQuotationButton in XAML
        }

        /// <summary>
        /// Handles the click event for the "Request Quotation" button.
        /// Navigates the user to the Request Quotation page if they are logged in.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void RequestQuotation_Click(object sender, RoutedEventArgs e)
        {
            if (RequestQuotationButton.IsEnabled)
            {
                NavigationService?.Navigate(new RequestQuotation()); // Navigate to the Request Quotation page
            }
            else
            {
                MessageBox.Show("You must be logged in to request a quotation.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Handles the click event for viewing quotations.
        /// Navigates the user to the Customer Quotation Overview page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ViewQuotations_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CustomerQuotationOverview());
        }

        /// <summary>
        /// Handles the click event for accessing the user profile.
        /// Displays the user profile information.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Accessing Profile");
        }

        /// <summary>
        /// Handles the click event for logging out.
        /// Logs out the user and navigates to the login page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logging out");
            NavigationService?.Navigate(new Login());
        }

        /// <summary>
        /// Displays unread notifications to the user.
        /// Marks notifications as read after displaying.
        /// </summary>
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

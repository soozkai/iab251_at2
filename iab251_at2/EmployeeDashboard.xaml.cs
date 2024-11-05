using System.Windows;
using System.Windows.Controls;
using iab251_at2.Services;

namespace iab251_at2
{
    /// <summary>
    /// Represents the employee dashboard page where employees can manage quotations and view rate schedules.
    /// </summary>
    public partial class EmployeeDashboard : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeDashboard"/> class.
        /// Displays unread notifications when the dashboard is loaded.
        /// </summary>
        public EmployeeDashboard()
        {
            InitializeComponent();
            DisplayNotifications();
        }

        /// <summary>
        /// Displays unread notifications to the employee.
        /// Marks notifications as read after displaying them.
        /// </summary>
        private void DisplayNotifications()
        {
            var notifications = NotificationService.GetUnreadNotifications();
            foreach (var notification in notifications)
            {
                MessageBox.Show(notification.Message, "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                notification.IsRead = true; // Mark notification as read after displaying
            }
        }

        /// <summary>
        /// Handles the click event for the "View Quotations" button.
        /// Opens the view quotations window and navigates back from the dashboard.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ViewQuotationsButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the view quotations window
            ViewQuotations viewQuotationsWindow = new ViewQuotations();
            viewQuotationsWindow.Show();

            // Close the dashboard page
            NavigationService?.GoBack();
        }

        /// <summary>
        /// Handles the click event for the "View Rate Schedule" button.
        /// Opens the rate schedule window for the employee to view rates.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ViewRateScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            RateSchedule rateScheduleWindow = new RateSchedule();
            rateScheduleWindow.ShowDialog();
        }

        /// <summary>
        /// Handles the click event for the "Logout" button.
        /// Logs out the employee and navigates back to the main window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            NavigationService?.GoBack();
        }
    }
}

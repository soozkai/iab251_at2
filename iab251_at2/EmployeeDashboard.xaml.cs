using System.Windows;
using System.Windows.Controls;
using iab251_at2.Services;

namespace iab251_at2
{
    public partial class EmployeeDashboard : Page
    {
        public EmployeeDashboard()
        {
            InitializeComponent();
            DisplayNotifications();
        }

        private void DisplayNotifications()
        {
            var notifications = NotificationService.GetUnreadNotifications();
            foreach (var notification in notifications)
            {
                MessageBox.Show(notification.Message, "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                notification.IsRead = true; // Mark notification as read after displaying
            }
        }

        private void ViewQuotationsButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the view quotations window
            ViewQuotations viewQuotationsWindow = new ViewQuotations();
            viewQuotationsWindow.Show();

            // Close the dashboard page
            NavigationService?.GoBack();
        }

        private void ViewRateScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            RateSchedule rateScheduleWindow = new RateSchedule();
            rateScheduleWindow.ShowDialog();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            NavigationService?.GoBack();
        }
    }
}

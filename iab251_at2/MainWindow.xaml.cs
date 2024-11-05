using System.Windows;
using System.Windows.Controls;

namespace iab251_at2
{
    /// <summary>
    /// Represents the main window of the application, providing navigation
    /// to various user functionalities such as registration and login.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Navigates to the Customer Registration page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void RegisterCustomer_Click(object sender, RoutedEventArgs e)
        {
            MainOptionsContainer.Visibility = Visibility.Collapsed;
            MainFrame.Visibility = Visibility.Visible;
            MainFrame.Navigate(new CustomerRegistration());
        }

        /// <summary>
        /// Navigates to the Employee Registration page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void RegisterEmployee_Click(object sender, RoutedEventArgs e)
        {
            MainOptionsContainer.Visibility = Visibility.Collapsed;
            MainFrame.Visibility = Visibility.Visible;
            MainFrame.Navigate(new EmployeeRegistration());
        }

        /// <summary>
        /// Navigates to the Login page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            MainOptionsContainer.Visibility = Visibility.Collapsed;
            MainFrame.Visibility = Visibility.Visible;
            MainFrame.Navigate(new Login());
        }

        /// <summary>
        /// Displays the main options panel and hides the main frame.
        /// This is typically called when navigating back to the main options.
        /// </summary>
        public void ShowMainOptions()
        {
            MainOptionsContainer.Visibility = Visibility.Visible;
            MainFrame.Visibility = Visibility.Collapsed;
        }
    }
}

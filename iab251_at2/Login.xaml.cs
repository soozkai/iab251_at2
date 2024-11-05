using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Security.Cryptography;
using System.Windows.Controls;

namespace iab251_at2
{
    /// <summary>
    /// Represents the login page where users can authenticate themselves.
    /// </summary>
    public partial class Login : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class.
        /// </summary>
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the login button. Validates user input,
        /// checks the entered credentials against registered employees and customers,
        /// and navigates to the appropriate dashboard upon successful login.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check against registered employees
            var employee = EmployeeRegistration.employeeList
                .FirstOrDefault(e => e.Email == username && e.HashedPassword == HashPassword(password));

            if (employee != null)
            {
                MessageBox.Show("Login successful! Welcome, employee.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Navigate to the EmployeeDashboard page
                NavigationService?.Navigate(new EmployeeDashboard());
                return;
            }

            // Check against registered customers
            var customer = CustomerRegistration.customerList
                .FirstOrDefault(c => c.Email == username && c.HashedPassword == HashPassword(password));

            if (customer != null)
            {
                MessageBox.Show("Login successful! Welcome, customer.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Navigate to the CustomerDashboard page and enable Request Quotation functionality
                var customerDashboard = new CustomerDashboard();
                customerDashboard.EnableRequestQuotation(); // Assumes EnableRequestQuotation method is defined in CustomerDashboard
                NavigationService?.Navigate(customerDashboard);
                return;
            }

            // If no match is found in either list
            MessageBox.Show("Invalid username or password.", "Authentication Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Hashes the provided password using SHA256 to ensure secure storage.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hashed password as a hexadecimal string.</returns>
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Handles the click event of the cancel button to navigate back to the main options.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow?.ShowMainOptions();
        }
    }
}

using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Security.Cryptography;
using System.Windows.Controls;

namespace iab251_at2
{
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow?.ShowMainOptions();
        }
    }
}

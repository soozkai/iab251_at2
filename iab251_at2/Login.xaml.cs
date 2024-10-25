using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Security.Cryptography;

namespace iab251_at2
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text; // Get the email as the username
            string password = PasswordBox.Password; // Get the entered password

            // Simple input validation
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
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                // Navigate to the next page (e.g., dashboard)
                this.Close(); // Close the login window
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Authentication Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            this.Close(); // Close the login window
        }
    }
}

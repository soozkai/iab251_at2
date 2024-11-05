using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace iab251_at2
{
    /// <summary>
    /// Represents the customer registration page where new customers can register.
    /// </summary>
    public partial class CustomerRegistration : Page
    {
        /// <summary>
        /// Class to store customer details in memory.
        /// </summary>
        public class Customer
        {
            /// <summary>
            /// Gets or sets the customer's first name.
            /// </summary>
            public string FirstName { get; set; }

            /// <summary>
            /// Gets or sets the customer's family name.
            /// </summary>
            public string FamilyName { get; set; }

            /// <summary>
            /// Gets or sets the customer's email address.
            /// </summary>
            public string Email { get; set; }

            /// <summary>
            /// Gets or sets the customer's phone number.
            /// </summary>
            public string PhoneNumber { get; set; }

            /// <summary>
            /// Gets or sets the customer's company name (optional).
            /// </summary>
            public string CompanyName { get; set; }

            /// <summary>
            /// Gets or sets the customer's address.
            /// </summary>
            public string Address { get; set; }

            /// <summary>
            /// Gets or sets the hashed password for the customer.
            /// </summary>
            public string HashedPassword { get; set; } // Store password securely
        }

        // A simple in-memory storage for customers
        public static readonly List<Customer> customerList = new List<Customer>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRegistration"/> class.
        /// </summary>
        public CustomerRegistration()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event for the register button. Validates input and registers a new customer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(FamilyNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(AddressTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("All fields except Company Name must be filled in.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Password hashing
            string hashedPassword = HashPassword(PasswordBox.Password);

            // Create and add customer object
            Customer newCustomer = new Customer
            {
                FirstName = FirstNameTextBox.Text,
                FamilyName = FamilyNameTextBox.Text,
                Email = EmailTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text,
                CompanyName = CompanyNameTextBox.Text, // Optional field
                Address = AddressTextBox.Text,
                HashedPassword = hashedPassword
            };

            customerList.Add(newCustomer);

            MessageBox.Show("Registration Successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear form fields after registration
            ClearFields();
        }

        /// <summary>
        /// Handles the click event for the cancel button and navigates back to the main options.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow?.ShowMainOptions(); // Directly show the main menu
        }

        /// <summary>
        /// Clears all input fields in the registration form.
        /// </summary>
        private void ClearFields()
        {
            FirstNameTextBox.Clear();
            FamilyNameTextBox.Clear();
            EmailTextBox.Clear();
            PhoneNumberTextBox.Clear();
            CompanyNameTextBox.Clear();
            AddressTextBox.Clear();
            PasswordBox.Clear();
        }

        /// <summary>
        /// Hashes the provided password using SHA256.
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
    }
}

using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace iab251_at2
{
    public partial class CustomerRegistration : Page
    {
        // Class to store customer details in memory
        public class Customer
        {
            public string FirstName { get; set; }
            public string FamilyName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string CompanyName { get; set; }
            public string Address { get; set; }
            public string HashedPassword { get; set; } // Store password securely
        }

        // A simple in-memory storage for customers
        public static readonly List<Customer> customerList = new List<Customer>();

        public CustomerRegistration()
        {
            InitializeComponent();
        }

        // Register Button Click Event
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


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow?.ShowMainOptions(); // Directly show the main menu
        }

        
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

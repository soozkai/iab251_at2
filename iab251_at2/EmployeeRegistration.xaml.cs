using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace iab251_at2
{
    public partial class EmployeeRegistration : Page
    {
        public class Employee
        {
            public string FirstName { get; set; } = string.Empty;
            public string FamilyName { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string PhoneNumber { get; set; } = string.Empty;
            public string EmployeeType { get; set; } = string.Empty; // Will hold selected employee type
            public string Address { get; set; } = string.Empty;
            public string HashedPassword { get; set; } = string.Empty; 
        }

        public static readonly List<Employee> employeeList = new List<Employee>();

        public EmployeeRegistration()
        {
            InitializeComponent();
        }

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
                MessageBox.Show("All fields must be filled in.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Password hashing
            string hashedPassword = HashPassword(PasswordBox.Password);

            // Create and add employee object
            Employee newEmployee = new Employee
            {
                FirstName = FirstNameTextBox.Text,
                FamilyName = FamilyNameTextBox.Text,
                Email = EmailTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text,
                EmployeeType = (EmployeeTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(), 
                Address = AddressTextBox.Text,
                HashedPassword = hashedPassword
            };

            employeeList.Add(newEmployee);

            
            MessageBox.Show("Employee registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow?.ShowMainOptions();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow?.ShowMainOptions(); 
        }

        private void ClearFields()
        {
            FirstNameTextBox.Clear();
            FamilyNameTextBox.Clear();
            EmailTextBox.Clear();
            PhoneNumberTextBox.Clear();
            AddressTextBox.Clear();
            PasswordBox.Clear();
            EmployeeTypeComboBox.SelectedIndex = 0;
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

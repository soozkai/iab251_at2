using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace iab251_at2
{
    /// <summary>
    /// Represents the employee registration page where new employees can be registered.
    /// </summary>
    public partial class EmployeeRegistration : Page
    {
        /// <summary>
        /// Represents an employee with personal and contact details.
        /// </summary>
        public class Employee
        {
            /// <summary>
            /// Gets or sets the first name of the employee.
            /// </summary>
            public string FirstName { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the family name of the employee.
            /// </summary>
            public string FamilyName { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the email address of the employee.
            /// </summary>
            public string Email { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the phone number of the employee.
            /// </summary>
            public string PhoneNumber { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the type of employee (e.g., admin, user).
            /// </summary>
            public string EmployeeType { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the address of the employee.
            /// </summary>
            public string Address { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the hashed password of the employee for secure storage.
            /// </summary>
            public string HashedPassword { get; set; } = string.Empty;
        }

        /// <summary>
        /// A static list to hold registered employees in memory.
        /// </summary>
        public static readonly List<Employee> employeeList = new List<Employee>();

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRegistration"/> class.
        /// </summary>
        public EmployeeRegistration()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the register button to register a new employee.
        /// Validates input fields and adds a new employee to the employee list.
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

        /// <summary>
        /// Clears the input fields on the registration form.
        /// </summary>
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

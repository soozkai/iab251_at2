using System.Windows;

namespace iab251_at2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Register as Customer button click handler
        private void RegisterCustomer_Click(object sender, RoutedEventArgs e)
        {
            // Open the customer registration window
            CustomerRegistration customerRegistrationWindow = new CustomerRegistration();
            customerRegistrationWindow.ShowDialog(); // Show as a modal dialog
        }

        // Register as Employee button click handler
        private void RegisterEmployee_Click(object sender, RoutedEventArgs e)
        {
            // Open the employee registration window
            EmployeeRegistration employeeRegistrationWindow = new EmployeeRegistration();
            employeeRegistrationWindow.ShowDialog(); // Show as a modal dialog
        }

        // Log In button click handler
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Open the login window
            Login loginWindow = new Login();
            loginWindow.ShowDialog(); // Show as a modal dialog
        }
    }
}

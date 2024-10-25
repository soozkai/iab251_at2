using System.Windows;

namespace iab251_at2
{
    public partial class CustomerDashboard : Window
    {
        public CustomerDashboard()
        {
            InitializeComponent();
        }

        // Method to handle viewing quotations
        private void ViewQuotations_Click(object sender, RoutedEventArgs e)
        {
            // Logic to display quotations
            MessageBox.Show("Viewing Quotations");
        }

        // Method to handle profile access
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            // Logic to display profile
            MessageBox.Show("Accessing Profile");
        }

        // Method to handle logging out
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            // Logic to log out the user
            MessageBox.Show("Logging out");
            this.Close(); // Close the dashboard
        }
    }
}

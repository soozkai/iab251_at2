using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace iab251_at2
{
    public partial class EmployeeDashboard : Page
    {
        public EmployeeDashboard()
        {
            InitializeComponent();
        }

        private void ViewQuotationsButton_Click(object sender, RoutedEventArgs e)
        {
            //open the view quotation window
            ViewQuotations viewQuotationsWindow = new ViewQuotations();
            viewQuotationsWindow.Show();
            //close the dashboard window
            NavigationService?.GoBack();
        }

        private void LogoutButton_Click(Object sender, RoutedEventArgs e)
        {
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            NavigationService?.GoBack();
        }
    }
}
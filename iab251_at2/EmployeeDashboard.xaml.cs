using System.Runtime.CompilerServices;
using System.Windows;

namespace iab251_at2
{
    public partial class EmployeeDashboard : Window
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
            this.Close();
        }

        private void LogoutButton_Click(Object sender, RoutedEventArgs e)
        {
            //Logic to logout and return back to the main menu (login/registration screen)
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            //close the window
            this.Close();
        }
    }
}
using System.Windows.Navigation;
using System.Windows;

namespace iab251_at2
{
    internal class QuotationService
    {
        public QuotationService()
        {
        }

        internal bool SaveQuotationRequest(QuotationRequest quotationRequest)
        {
            // Placeholder for save logic
            bool isSaved = true; // Replace this with actual save logic

            if (isSaved)
            {
                MessageBox.Show("Request submitted successfully! Navigating to the dashboard.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Navigate to the CustomerDashboard page via Frame in MainWindow
                ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new CustomerDashboard());
                return true;
            }
            else
            {
                MessageBox.Show("Failed to submit the request. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }


    }
}
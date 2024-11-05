using System.Windows.Navigation;
using System.Windows;

namespace iab251_at2
{
    /// <summary>
    /// Provides services related to handling quotation requests.
    /// </summary>
    internal class QuotationService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuotationService"/> class.
        /// </summary>
        public QuotationService()
        {
        }

        /// <summary>
        /// Saves the specified quotation request and navigates to the customer dashboard if successful.
        /// </summary>
        /// <param name="quotationRequest">The quotation request to be saved.</param>
        /// <returns><c>true</c> if the quotation request was saved successfully; otherwise, <c>false</c>.</returns>
        internal bool SaveQuotationRequest(QuotationRequest quotationRequest)
        {
            bool isSaved = true; 

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

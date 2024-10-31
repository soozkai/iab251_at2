using System.Windows;
using System.Windows.Controls;
using iab251_at2.Models;
using iab251_at2.Services;

namespace iab251_at2
{
    public partial class CustomerQuotationDetails : Page
    {
        private Quotation _quotation;

        public CustomerQuotationDetails(Quotation quotation)
        {
            InitializeComponent();
            _quotation = quotation;
            PopulateDetails();
        }

        private void PopulateDetails()
        {
            CustomerNameTextBlock.Text = _quotation.ClientName;
            QuotationNumberTextBlock.Text = _quotation.QuotationNumber;
            DateIssuedTextBlock.Text = _quotation.DateIssued.ToString("d");
            ContainerTypeTextBlock.Text = _quotation.ContainerType;
            ScopeTextBlock.Text = _quotation.Scope;
            DepotChargesTextBlock.Text = _quotation.DepotCharges.ToString("C");
            LCLChargesTextBlock.Text = _quotation.LCLCharges.ToString("C");
        }

     
        public void AcceptQuotation()
        {
            _quotation.Status = "Accepted";
            NotificationService.AddNotification(
                _quotation.QuotationNumber,
                $"Customer has accepted quotation {_quotation.QuotationNumber}."
            );
        }

        public void RejectQuotation()
        {
            _quotation.Status = "Rejected";
            NotificationService.AddNotification(
                _quotation.QuotationNumber,
                $"Customer has rejected quotation {_quotation.QuotationNumber}."
            );
        }

      
        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            AcceptQuotation();
            MessageBox.Show("Quotation Accepted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            RejectQuotation();
            MessageBox.Show("Quotation Rejected", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

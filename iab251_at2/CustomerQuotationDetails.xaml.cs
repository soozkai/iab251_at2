using System;
using System.Windows;
using System.Windows.Controls;
using iab251_at2.Models;
using iab251_at2.Services;

namespace iab251_at2
{
    public partial class CustomerQuotationDetails : Page
    {
        private Quotation _quotation;

        public CustomerQuotationDetails(Quotation quotation = null)
        {
            InitializeComponent();
            if (quotation != null)
            {
                _quotation = quotation;
            }
            else
            {
                _quotation = CreateNewQuotation(); // Create a new quotation if not provided
            }
            PopulateDetails();
        }

        // Method to create a new quotation request
        private Quotation CreateNewQuotation()
        {
            var newQuotation = new Quotation
            {
                QuotationNumber = Guid.NewGuid().ToString(),
                ClientName = "Customer Name", // Placeholder; in practice, retrieve customer data
                ContainerType = "Standard",
                NumberOfContainers = 1, // Default or user input
                QuarantineRequired = false,
                FumigationRequired = false,
                Scope = "Freight details here...",
                DateIssued = DateTime.Now,
                Status = "New"
            };

            // Apply discount if applicable
            newQuotation.ApplyDiscount();
            NotificationService.AddNotification(
                newQuotation.QuotationNumber,
                $"New Quotation Created: {newQuotation.QuotationNumber}"
            );

            return newQuotation;
        }

        // Populate UI elements with quotation details
        private void PopulateDetails()
        {
            CustomerNameTextBlock.Text = _quotation.ClientName;
            QuotationNumberTextBlock.Text = _quotation.QuotationNumber;
            DateIssuedTextBlock.Text = _quotation.DateIssued.ToString("d");
            ContainerTypeTextBlock.Text = _quotation.ContainerType;
            ScopeTextBlock.Text = _quotation.Scope;
            DepotChargesTextBlock.Text = _quotation.DepotCharges.ToString("C");
            LCLChargesTextBlock.Text = _quotation.LCLCharges.ToString("C");
            DiscountAppliedTextBlock.Text = $"{_quotation.DiscountPercentage}%";
        }

        // Accept or Reject the quotation
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

        // Event handler for accepting quotation
        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            AcceptQuotation();
            MessageBox.Show("Quotation Accepted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Event handler for rejecting quotation
        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            RejectQuotation();
            MessageBox.Show("Quotation Rejected", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Submit the new quotation request
        private void SubmitQuotation_Click(object sender, RoutedEventArgs e)
        {
            // Assuming quotation is validated and ready for submission
            MessageBox.Show($"Quotation {_quotation.QuotationNumber} submitted successfully!", "Submission Successful", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

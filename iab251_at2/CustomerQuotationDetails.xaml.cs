using System;
using System.Windows;
using System.Windows.Controls;
using iab251_at2.Models;
using iab251_at2.Services;

namespace iab251_at2
{
    /// <summary>
    /// Represents the details of a customer quotation, allowing the customer to accept or reject it.
    /// </summary>
    public partial class CustomerQuotationDetails : Page
    {
        private Quotation _quotation;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerQuotationDetails"/> class.
        /// If a quotation is provided, it populates the details; otherwise, creates a new quotation.
        /// </summary>
        /// <param name="quotation">The quotation to be displayed (optional).</param>
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

        /// <summary>
        /// Creates a new quotation request with default values and applies any applicable discounts.
        /// </summary>
        /// <returns>A new instance of the <see cref="Quotation"/> class.</returns>
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

        /// <summary>
        /// Populates the UI elements with the details of the current quotation.
        /// </summary>
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

        /// <summary>
        /// Accepts the current quotation and sends a notification to the quotation officer.
        /// </summary>
        public void AcceptQuotation()
        {
            _quotation.Status = "Accepted";
            NotificationService.AddNotification(
                _quotation.QuotationNumber,
                $"Customer has accepted quotation {_quotation.QuotationNumber}."
            );
        }

        /// <summary>
        /// Rejects the current quotation and sends a notification to the quotation officer.
        /// </summary>
        public void RejectQuotation()
        {
            _quotation.Status = "Rejected";
            NotificationService.AddNotification(
                _quotation.QuotationNumber,
                $"Customer has rejected quotation {_quotation.QuotationNumber}."
            );
        }

        /// <summary>
        /// Event handler for the Accept button click event. 
        /// Accepts the quotation and shows a success message.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            AcceptQuotation();
            MessageBox.Show("Quotation Accepted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Event handler for the Reject button click event. 
        /// Rejects the quotation and shows a success message.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            RejectQuotation();
            MessageBox.Show("Quotation Rejected", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Submits the new quotation request and shows a submission success message.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void SubmitQuotation_Click(object sender, RoutedEventArgs e)
        {
            // Assuming quotation is validated and ready for submission
            MessageBox.Show($"Quotation {_quotation.QuotationNumber} submitted successfully!", "Submission Successful", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using iab251_at2.Models;
using iab251_at2.Services;

namespace iab251_at2
{
    public partial class ViewQuotations : Window
    {
        private List<Quotation> quotations;

        public ViewQuotations()
        {
            InitializeComponent();
            LoadQuotations();
        }

        private void LoadQuotations()
        {
            // Sample quotations with various statuses
            quotations = new List<Quotation>
            {
                new Quotation
                {
                    QuotationNumber = "Q1234",
                    ClientName = "John Doe",
                    DateIssued = DateTime.Now.AddDays(-2),
                    Status = "Pending",
                    ContainerType = "20 ft",
                    Scope = "Import of electronics",
                    DepotCharges = 100.00m,
                    LCLCharges = 200.00m,
                    NumberOfContainers = 3,
                    QuarantineRequired = false,
                    FumigationRequired = true
                },
                new Quotation
                {
                    QuotationNumber = "Q1235",
                    ClientName = "Jane Smith",
                    DateIssued = DateTime.Now.AddDays(-1),
                    Status = "Accepted",
                    ContainerType = "40 ft",
                    Scope = "Export of textiles",
                    DepotCharges = 150.00m,
                    LCLCharges = 250.00m,
                    NumberOfContainers = 5,
                    QuarantineRequired = true,
                    FumigationRequired = false
                },
                new Quotation
                {
                    QuotationNumber = "Q1236",
                    ClientName = "ACME Corp",
                    DateIssued = DateTime.Now.AddDays(-3),
                    Status = "Pending",
                    ContainerType = "20 ft",
                    Scope = "Import of machinery",
                    DepotCharges = 200.00m,
                    LCLCharges = 300.00m,
                    NumberOfContainers = 11,
                    QuarantineRequired = true,
                    FumigationRequired = true
                }
            };

            QuotationDataGrid.ItemsSource = quotations;
        }

        private void QuotationDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedQuotation = (Quotation)QuotationDataGrid.SelectedItem;
            if (selectedQuotation != null)
            {
                QuotationDetails detailsWindow = new QuotationDetails(selectedQuotation);
                detailsWindow.WindowState = WindowState.Maximized;
                detailsWindow.ShowDialog();

                // Update the grid in case the status was changed in the details view
                QuotationDataGrid.Items.Refresh();
            }
        }

        private void QuotationDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedQuotation = (Quotation)QuotationDataGrid.SelectedItem;
            AcceptButton.IsEnabled = selectedQuotation != null;
            RejectButton.IsEnabled = selectedQuotation != null;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedQuotation = (Quotation)QuotationDataGrid.SelectedItem;
            if (selectedQuotation != null)
            {
                selectedQuotation.Status = "Accepted";
                ShowNotification(selectedQuotation, "accepted");

                // Send notification to the customer
                NotificationService.AddNotification(selectedQuotation.QuotationNumber,
                    $"Your quotation {selectedQuotation.QuotationNumber} has been accepted.");
            }
            else
            {
                MessageBox.Show("Please select a quotation to accept.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedQuotation = (Quotation)QuotationDataGrid.SelectedItem;
            if (selectedQuotation != null)
            {
                selectedQuotation.Status = "Rejected";
                ShowNotification(selectedQuotation, "rejected");

                // Send notification to the customer
                NotificationService.AddNotification(selectedQuotation.QuotationNumber,
                    $"Your quotation {selectedQuotation.QuotationNumber} has been rejected.");
            }
            else
            {
                MessageBox.Show("Please select a quotation to reject.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to show a notification to the Customer with updated status
        private void ShowNotification(Quotation quotation, string decision)
        {
            QuotationDataGrid.Items.Refresh();
            MessageBox.Show(
                $"Quotation {quotation.QuotationNumber} has been {decision}.",
                "Status Updated", MessageBoxButton.OK, MessageBoxImage.Information);

            // Send notification to customer
            if (decision == "rejected")
            {
                SendRejectionMessage(quotation.ClientName, quotation.QuotationNumber);
            }
            else if (decision == "accepted")
            {
                SendAcceptanceMessage(quotation.ClientName, quotation.QuotationNumber);
            }
        }

        // Method to simulate sending a message on acceptance
        private void SendAcceptanceMessage(string clientName, string quotationNumber)
        {
            MessageBox.Show(
                $"An acceptance message has been sent to {clientName} regarding quotation {quotationNumber}.",
                "Message Sent", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Method to simulate sending a message on rejection
        private void SendRejectionMessage(string clientName, string quotationNumber)
        {
            MessageBox.Show(
                $"A rejection message has been sent to {clientName} regarding quotation {quotationNumber}.",
                "Message Sent", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

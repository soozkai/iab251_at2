using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using iab251_at2.Models;


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

        // Load sample quotations into the DataGrid
        private void LoadQuotations()
        {
            // Create a list of sample quotations
            quotations = new List<Quotation>
            {
                new Quotation { QuotationNumber = "Q1234", ClientName = "John Doe", DateIssued = DateTime.Now.AddDays(-2), Status = "Pending" },
                new Quotation { QuotationNumber = "Q1235", ClientName = "Jane Smith", DateIssued = DateTime.Now.AddDays(-1), Status = "Accepted" },
                new Quotation { QuotationNumber = "Q1236", ClientName = "ACME Corp", DateIssued = DateTime.Now.AddDays(-3), Status = "Rejected" }
            };

            // Bind the list to the DataGrid
            QuotationDataGrid.ItemsSource = quotations;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedQuotation = (Quotation)QuotationDataGrid.SelectedItem;
            if (selectedQuotation != null)
            {
                selectedQuotation.Status = "Accepted";
                MessageBox.Show($"Quotation {selectedQuotation.QuotationNumber} has been accepted.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                // Optionally, you may want to refresh the DataGrid here.
                QuotationDataGrid.Items.Refresh();
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
                SendRejectionMessage(selectedQuotation.ClientName, selectedQuotation.QuotationNumber);
                MessageBox.Show($"Quotation {selectedQuotation.QuotationNumber} has been rejected.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                QuotationDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a quotation to reject.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SendRejectionMessage(string clientName, string quotationNumber)
        {
            // Here you would implement the logic to send a message to the customer
            MessageBox.Show($"A rejection message has been sent to {clientName} regarding quotation {quotationNumber}.", "Message Sent", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}

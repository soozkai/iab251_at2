using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

        private void LoadQuotations()
        {
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
                MessageBox.Show($"Quotation {selectedQuotation.QuotationNumber} has been accepted.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
            MessageBox.Show($"A rejection message has been sent to {clientName} regarding quotation {quotationNumber}.", "Message Sent", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

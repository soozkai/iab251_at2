using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using iab251_at2.Models;
namespace iab251_at2
{
    public partial class ViewQuotations : Window
    {
        public ViewQuotations()
        {
            InitializeComponent();
            LoadQuotations();
        }

        // Load sample quotations into the DataGrid
        private void LoadQuotations()
        {
            // Create a list of sample quotations
            List<Quotation> quotations = new List<Quotation>
            {
                new Quotation { QuotationNumber = "Q1234", ClientName = "John Doe", DateIssued = DateTime.Now.AddDays(-2), Status = "Pending" },
                new Quotation { QuotationNumber = "Q1235", ClientName = "Jane Smith", DateIssued = DateTime.Now.AddDays(-1), Status = "Accepted" },
                new Quotation { QuotationNumber = "Q1236", ClientName = "ACME Corp", DateIssued = DateTime.Now.AddDays(-3), Status = "Rejected" }
            };

            // Bind the list to the DataGrid
            QuotationDataGrid.ItemsSource = quotations;
        }
    }
}

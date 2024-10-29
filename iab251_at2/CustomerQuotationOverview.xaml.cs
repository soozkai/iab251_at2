using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using iab251_at2.Models;

namespace iab251_at2
{
    public partial class CustomerQuotationOverview : Page
    {
        public CustomerQuotationOverview()
        {
            InitializeComponent();
            LoadQuotations();
        }

        private void LoadQuotations()
        {
            QuotationListView.ItemsSource = new List<Quotation>
            {
                new Quotation { QuotationNumber = "Q1234", DateIssued = DateTime.Now.AddDays(-2), Status = "Pending", ClientName = "John Doe", ContainerType = "20 ft", Scope = "Electronics Import", DepotCharges = 150.00m, LCLCharges = 200.00m },
                new Quotation { QuotationNumber = "Q1235", DateIssued = DateTime.Now.AddDays(-1), Status = "Accepted", ClientName = "Jane Smith", ContainerType = "40 ft", Scope = "Textiles Export", DepotCharges = 250.00m, LCLCharges = 300.00m }
            };
        }

        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Quotation selectedQuotation = button.DataContext as Quotation;
            if (selectedQuotation != null)
            {
                // Navigate to CustomerQuotationDetails page, passing the selected quotation
                NavigationService?.Navigate(new CustomerQuotationDetails(selectedQuotation));
            }
        }
    }
}

using System.Collections.Generic;
using System.Windows;
using.System.Windows.Controls;
using System.Windows.Input;
using iab251_at2;
using iab251_at2.Models;


//White box testing the view quotations cs program.
namespace iab251_at2.Tests
{
    [TestClass]
    public class ViewQuotationsTests
    [
        private ViewQuotations viewQuotations;
        [TestInitialize]
        public void Setup()
        {
            //Create an instant for the viewquotations class to play
            viewQuotations = new ViewQuotations();
            //simualte the loading of the quotations
            viewQuotations.LoadQuotations();
        
        }

        [TestMethod]
        public void LoadQuotations_ShouldPopulateQuotationList()
        {
            var quotationList = viewQuotations.QuotationDataGrid.ItemsSource as List<Quotation>;
            Assert.IsNotNull(quotationList, "Quotation list should be populated");
            Assert.IsTrue(quotationList.Count > 0, "Quotations list should contain items.");
  
        }

        [TestMethod]
        public void AcceptButton_Click_ShouldUpdateStatusToAccept_SendNotification()
        {
            var quotation = new Quotation
            {
                quotationNumber = "Q1234",
                ClientName = "John Doe",
                Status = "Pending"
            };
            ViewQuotations.QuotationDataGrid.SelectedItem = quotation;

            ViewQuotations.AcceptButton_Click(null, null);
            Assert.AreEqual("Accepted", quotation.Status, "The status should be updated to 'Accepted'.");

        }

        [TestMethod]
        public void RejectButton_Click_ShouldUpdateStatusToRejected_SendNotification()
        {
            var quotation = new Quotation
            {
                QuotationNumber = "Q1236",
                ClientName = "ACME Corp",
                Status = "Pending"
            };
            viewQuotations.QuotationDataGrid.SelectedItem = quotation;

            ViewQuotations.RejectButton_Click(null, null);
            Assert.AreEqual("Rejected", quotation.Status, "The status should be updated to 'Rejected'.");

        }

        [TestMethod]
        public void QuotationDataGrid_SelectionChanged_ShouldEnableButtonWhenItemSelected()
        {
            var quotation = new Quotation
            {
                QuotationNumber = "Q1235",
                ClientName = "Jane Smith",
                Status = "Accepted"
            };
            ViewQuotations.QuotationDataGrid.SelectedItem = quotation;

            ViewQuotations.RejectButton_Click(null, null);
            
            Assert.IsTrue(viewQuotations.AcceptButton.IsEnabled, "AcceptButton should be enabled.");
            Assert.IsTrue(viewQuotations.RejectButton.IsEnabled, "RejectButton should be enabled.");
        
        }

        [TestMethod]
        public void QuotationDataGrid_MouseDoubleClick_ShouldOpenDetailsWindow()
        {
            var quotation = new Quotation
            {
                QuotationNumber = "Q1234",
                ClientName = "John Doe",
                Status = "Pending"
            };
            ViewQuotations.QuotationDataGrid.SelectedItem = quotation;

            bool windowOpened = false;

            Application.Current.Dispacther.Invoke(() =>
            {
                try
                {
                    ViewQuotations.QuotationDataGrid_MouseDoubleClick(null, null);
                    windowOpened = true;
                }
                catch
                {
                    windowOpened = false;
                }
            });

            Assert.IsTrue(windowOpened, "QuotationDetails window should be opened.");
        }
    ]
}
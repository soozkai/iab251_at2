using System;
using System.Windows;
using System.Windows.Controls;
using iab251_at2.Models;
using iab251_at2.Services;

namespace iab251_at2
{
    public partial class RequestQuotation : Page
    {
        public RequestQuotation()
        {
            InitializeComponent();
        }

        private void SubmitRequest_Click(object sender, RoutedEventArgs e)
        {
            // Step 1: Retrieve data from input fields
            string requestID = RequestIDTextBox.Text;
            string name = NameTextBox.Text;
            string email = EmailTextBox.Text;
            string source = SourceTextBox.Text;
            string destination = DestinationTextBox.Text;
            string containerCount = ContainersTextBox.Text;
            string packageNature = PackageNatureTextBox.Text;
            string jobNature = (JobNatureComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string packing = (PackingComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string quarantineRequirements = QuarantineTextBox.Text;
            DateTime? requestDate = RequestDatePicker.SelectedDate;

            // Step 2: Validate input data
            if (string.IsNullOrEmpty(requestID) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(source) || string.IsNullOrEmpty(destination) ||
                string.IsNullOrEmpty(containerCount) || string.IsNullOrEmpty(packageNature) ||
                string.IsNullOrEmpty(jobNature) || string.IsNullOrEmpty(packing) ||
                string.IsNullOrEmpty(quarantineRequirements) || !requestDate.HasValue)
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Step 3: Create a quotation request model
            var quotationRequest = new QuotationRequest
            {
                RequestID = requestID,
                Name = name,
                Email = email,
                Source = source,
                Destination = destination,
                ContainerCount = containerCount,
                PackageNature = packageNature,
                JobNature = jobNature,
                Packing = packing,
                QuarantineRequirements = quarantineRequirements,
                RequestDate = requestDate.Value
            };

            // Step 4: Use the service layer to save the request (assuming QuotationService exists)
            var quotationService = new QuotationService();
            bool isSaved = quotationService.SaveQuotationRequest(quotationRequest);

            // Step 5: Provide feedback to the user
            if (isSaved)
            {
                MessageBox.Show("Request submitted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearFields(); // Optional: clear fields after submission
            }
            else
            {
                MessageBox.Show("Failed to submit the request. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Helper method to clear the input fields after submission
        private void ClearFields()
        {
            RequestIDTextBox.Clear();
            NameTextBox.Clear();
            EmailTextBox.Clear();
            SourceTextBox.Clear();
            DestinationTextBox.Clear();
            ContainersTextBox.Clear();
            PackageNatureTextBox.Clear();
            JobNatureComboBox.SelectedIndex = -1;
            PackingComboBox.SelectedIndex = -1;
            QuarantineTextBox.Clear();
            RequestDatePicker.SelectedDate = null;
        }
    }
}

using System.Windows;
using iab251_at2.Models;

namespace iab251_at2
{
    /// <summary>
    /// Represents the window that displays detailed information about a quotation.
    /// </summary>
    public partial class QuotationDetails : Window
    {
        private Quotation _quotation;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuotationDetails"/> class.
        /// </summary>
        /// <param name="quotation">The quotation object containing details to display.</param>
        public QuotationDetails(Quotation quotation)
        {
            InitializeComponent();
            _quotation = quotation;
            PopulateDetails();
            CheckForDiscount();
        }

        /// <summary>
        /// Populates the UI elements with the details of the quotation.
        /// </summary>
        private void PopulateDetails()
        {
            ContainerTypeTextBlock.Text = _quotation.ContainerType;
            ScopeTextBlock.Text = _quotation.Scope;
            DepotChargesTextBlock.Text = _quotation.DepotCharges.ToString("C");
            LCLChargesTextBlock.Text = _quotation.LCLCharges.ToString("C");
            NumberOfContainersTextBlock.Text = _quotation.NumberOfContainers.ToString();
            QuarantineRequiredTextBlock.Text = _quotation.QuarantineRequired ? "Yes" : "No";
            FumigationRequiredTextBlock.Text = _quotation.FumigationRequired ? "Yes" : "No";
            DiscountAppliedTextBlock.Text = $"{_quotation.DiscountPercentage}%";
        }

        /// <summary>
        /// Checks if there is a discount available for the quotation.
        /// If a discount is available, prompts the user to apply it.
        /// </summary>
        private void CheckForDiscount()
        {
            double discount = _quotation.CalculateDiscount();
            if (discount > 0)
            {
                // Alert the user and give the option to apply or decline the discount
                var result = MessageBox.Show(
                    $"A discount of {discount}% is available based on the job nature. Would you like to apply it?",
                    "Discount Available",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Information);

                if (result == MessageBoxResult.Yes)
                {
                    _quotation.ApplyDiscount();
                    PopulateDetails(); // Update the displayed details with the applied discount
                    MessageBox.Show($"Discount of {_quotation.DiscountPercentage}% applied to the quotation.",
                        "Discount Applied", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Discount declined. No discount will be applied.", "Discount Declined", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        /// <summary>
        /// Event handler for the Back button click event.
        /// Closes the quotation details window.
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the details window
        }
    }
}

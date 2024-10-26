using System.Windows;
using iab251_at2.Models;

namespace iab251_at2
{
    public partial class QuotationDetails : Window
    {
        private Quotation _quotation;

        public QuotationDetails(Quotation quotation)
        {
            InitializeComponent();
            _quotation = quotation;
            PopulateDetails();
            CheckForDiscount();
        }

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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the details window
        }
    }
}

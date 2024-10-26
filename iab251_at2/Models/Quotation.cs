namespace iab251_at2.Models
{
    public class Quotation
    {
        public string QuotationNumber { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public DateTime DateIssued { get; set; }
        public string Status { get; set; } = string.Empty;
        public string ContainerType { get; set; } = string.Empty; // e.g., "20ft" or "40ft"
        public string Scope { get; set; } = string.Empty; // Description of the job
        public decimal DepotCharges { get; set; } = 0.0m; // Charges for depot
        public decimal LCLCharges { get; set; } = 0.0m; // Charges for LCL delivery
        public int NumberOfContainers { get; set; } = 0; // Number of containers
        public bool QuarantineRequired { get; set; } = false; // Is quarantine required?
        public bool FumigationRequired { get; set; } = false; // Is fumigation required?
        public double DiscountPercentage { get; private set; } = 0; // Discount percentage applied

        // Method to calculate potential discount based on criteria
        public double CalculateDiscount()
        {
            if (NumberOfContainers > 10 && QuarantineRequired && FumigationRequired)
            {
                return 10.0;
            }
            else if (NumberOfContainers > 5 && QuarantineRequired && FumigationRequired)
            {
                return 5.0;
            }
            else if (NumberOfContainers > 5 && (QuarantineRequired || FumigationRequired))
            {
                return 2.5;
            }
            return 0;
        }

        // Method to apply the discount to the charges
        public void ApplyDiscount()
        {
            DiscountPercentage = CalculateDiscount();
            if (DiscountPercentage > 0)
            {
                decimal discountFactor = 1 - ((decimal)DiscountPercentage / 100);
                DepotCharges *= discountFactor;
                LCLCharges *= discountFactor;
            }
        }
    }
}

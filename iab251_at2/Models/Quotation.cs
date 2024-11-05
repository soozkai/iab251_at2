using System;

namespace iab251_at2.Models
{
    /// <summary>
    /// Represents a quotation for services provided to a customer.
    /// This class holds all the necessary details related to the quotation, including customer information, 
    /// charges, and potential discounts.
    /// </summary>
    public class Quotation
    {
        /// <summary>
        /// Gets or sets the unique identifier for the quotation.
        /// </summary>
        public string QuotationNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the client associated with the quotation.
        /// </summary>
        public string ClientName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date when the quotation was issued.
        /// </summary>
        public DateTime DateIssued { get; set; }

        /// <summary>
        /// Gets or sets the current status of the quotation.
        /// This can include statuses such as "Pending", "Accepted", or "Rejected".
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the customer's decision regarding the quotation.
        /// The default value is "Pending".
        /// </summary>
        public string Decision { get; set; } = "Pending";

        /// <summary>
        /// Gets or sets the type of container for the quotation (e.g., "20ft" or "40ft").
        /// </summary>
        public string ContainerType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a description of the job scope associated with the quotation.
        /// </summary>
        public string Scope { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the depot charges associated with the quotation.
        /// </summary>
        public decimal DepotCharges { get; set; } = 0.0m;

        /// <summary>
        /// Gets or sets the charges for LCL (Less than Container Load) delivery.
        /// </summary>
        public decimal LCLCharges { get; set; } = 0.0m;

        /// <summary>
        /// Gets or sets the number of containers for the quotation.
        /// </summary>
        public int NumberOfContainers { get; set; } = 0;

        /// <summary>
        /// Gets or sets a value indicating whether quarantine is required for the quotation.
        /// </summary>
        public bool QuarantineRequired { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether fumigation is required for the quotation.
        /// </summary>
        public bool FumigationRequired { get; set; } = false;

        /// <summary>
        /// Gets the percentage of discount applied to the quotation.
        /// </summary>
        public double DiscountPercentage { get; private set; } = 0;

        /// <summary>
        /// Calculates the potential discount based on predefined criteria.
        /// </summary>
        /// <returns>The calculated discount percentage.</returns>
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

        /// <summary>
        /// Applies the calculated discount to the depot and LCL charges.
        /// </summary>
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

        /// <summary>
        /// Updates the decision status based on the customer's choice.
        /// </summary>
        /// <param name="decision">The decision made by the customer (e.g., "Accepted", "Rejected").</param>
        public void UpdateDecision(string decision)
        {
            Decision = decision;
        }
    }
}

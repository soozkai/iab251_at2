using System;

namespace iab251_at2
{
    /// <summary>
    /// Represents a quotation request from a customer.
    /// </summary>
    internal class QuotationRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier for the quotation request.
        /// </summary>
        public string RequestID { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer making the request.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the customer.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the source location for the request.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the destination location for the request.
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets the number of containers involved in the request.
        /// </summary>
        public string ContainerCount { get; set; }

        /// <summary>
        /// Gets or sets the nature of the package (e.g., Fragile, Perishable).
        /// </summary>
        public string PackageNature { get; set; }

        /// <summary>
        /// Gets or sets the nature of the job (e.g., Import, Export).
        /// </summary>
        public string JobNature { get; set; }

        /// <summary>
        /// Gets or sets whether packing or unpacking services are required.
        /// </summary>
        public string Packing { get; set; } // Added field for Packing or Unpacking

        /// <summary>
        /// Gets or sets the quarantine requirements for the request, if any.
        /// </summary>
        public string QuarantineRequirements { get; set; } // Added field for Quarantine requirements

        /// <summary>
        /// Gets or sets the type of service requested (e.g., Standard, Express).
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// Gets or sets the date when the request was made.
        /// </summary>
        public DateTime RequestDate { get; set; }
    }
}

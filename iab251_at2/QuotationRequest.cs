using System;

namespace iab251_at2
{
    internal class QuotationRequest
    {
        public string RequestID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string ContainerCount { get; set; }
        public string PackageNature { get; set; }
        public string JobNature { get; set; }
        public string Packing { get; set; } // Added field for Packing or Unpacking
        public string QuarantineRequirements { get; set; } // Added field for Quarantine requirements
        public string Service { get; set; }
        public DateTime RequestDate { get; set; }
    }
}

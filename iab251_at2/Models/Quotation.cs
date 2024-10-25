using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iab251_at2.Models
{
    public class Quotation
    {
        
        public required string QuotationNumber { get; set; }
        public required string ClientName { get; set; }
        public DateTime DateIssued { get; set; }
        public required string Status { get; set; }

  
    }
}


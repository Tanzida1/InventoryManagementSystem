using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Entities
{
    public class Quotation
    {
        public int QuotationId { get; set; }

        public int SupplierId { get; set; }

        public string QuotationNumber { get; set; } = string.Empty;

        public DateTime QuotationDate { get; set; }

        public DateTime? ValidUntil { get; set; }

        public string Status { get; set; } = "Received";


        // Navigation Properties
        public Supplier Supplier { get; set; } = null!;

        public ICollection<QuotationDetail> QuotationDetails { get; set; }
            = new List<QuotationDetail>();

        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
            = new List<PurchaseOrder>();
    }
}

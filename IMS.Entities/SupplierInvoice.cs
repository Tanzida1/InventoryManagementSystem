using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Entities
{
    public class SupplierInvoice
    {
        public int SupplierInvoiceId { get; set; }

        public int SupplierId { get; set; }

        public string InvoiceNumber { get; set; } = string.Empty;

        public DateTime InvoiceDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string MatchingStatus { get; set; } = "Pending";


        // Navigation Properties
        public Supplier Supplier { get; set; } = null!;

        public ICollection<SupplierInvoiceDetail> SupplierInvoiceDetails { get; set; }
            = new List<SupplierInvoiceDetail>();
    }
}

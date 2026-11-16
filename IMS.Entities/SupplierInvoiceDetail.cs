using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Entities
{
    public class SupplierInvoiceDetail
    {
        public int InvoiceDetailId { get; set; }

        public int SupplierInvoiceId { get; set; }

        public int PODetailId { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }


        // Navigation Properties
        public SupplierInvoice SupplierInvoice { get; set; } = null!;

        public PurchaseOrderDetail PurchaseOrderDetail { get; set; } = null!;

        public ICollection<InvoiceReceiptMatch> InvoiceReceiptMatches { get; set; }
            = new List<InvoiceReceiptMatch>();
    }
}

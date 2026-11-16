using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class InvoiceReceiptMatch
    {
        public int MatchId { get; set; }

        public int InvoiceDetailId { get; set; }

        public int GRNDetailId { get; set; }

        public decimal MatchedQuantity { get; set; }


        // Navigation Properties
        public SupplierInvoiceDetail SupplierInvoiceDetail { get; set; } = null!;

        public GoodsReceiptDetail GoodsReceiptDetail { get; set; } = null!;
    }
}

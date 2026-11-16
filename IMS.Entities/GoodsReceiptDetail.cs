using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class GoodsReceiptDetail
    {
        public int GRNDetailId { get; set; }

        public int GoodsReceiptId { get; set; }

        public int PODetailId { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public decimal AcceptedQuantity { get; set; }

        public decimal DamagedQuantity { get; set; }


        // Navigation Properties
        public GoodsReceipt GoodsReceipt { get; set; } = null!;

        public PurchaseOrderDetail PurchaseOrderDetail { get; set; } = null!;

        public ICollection<InvoiceReceiptMatch> InvoiceReceiptMatches { get; set; }
            = new List<InvoiceReceiptMatch>();
    }
}

using IMS.Entities.Access;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Entities
{
    public class GoodsReceipt
    {
        public int GoodsReceiptId { get; set; }

        public string GRNNumber { get; set; } = string.Empty;

        public int PurchaseOrderId { get; set; }

        public DateTime ReceivedDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Pending";

        public int ReceivedBy { get; set; }


        // Navigation Properties
        public PurchaseOrder PurchaseOrder { get; set; } = null!;

        public User User { get; set; } = null!;

        public ICollection<GoodsReceiptDetail> GoodsReceiptDetails { get; set; }
            = new List<GoodsReceiptDetail>();
    }
}

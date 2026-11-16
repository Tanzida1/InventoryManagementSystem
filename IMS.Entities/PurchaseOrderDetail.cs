using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Entities
{
    public class PurchaseOrderDetail
    {
        public int PODetailId { get; set; }

        public int PurchaseOrderId { get; set; }

        public int ItemId { get; set; }

        public int? QuotationDetailId { get; set; }

        public decimal OrderedQuantity { get; set; }

        public decimal UnitPrice { get; set; }


        // Navigation Properties
        public PurchaseOrder PurchaseOrder { get; set; } = null!;

        public Item Item { get; set; } = null!;

        public QuotationDetail? QuotationDetail { get; set; }

        public ICollection<GoodsReceiptDetail> GoodsReceiptDetails { get; set; }
            = new List<GoodsReceiptDetail>();

        public ICollection<SupplierInvoiceDetail> SupplierInvoiceDetails { get; set; }
            = new List<SupplierInvoiceDetail>();
    }
}

using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Entities
{
    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }

        public string PONumber { get; set; } = string.Empty;

        public int SupplierId { get; set; }

        public int WarehouseId { get; set; }

        public int? QuotationId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Pending";

        public decimal TotalAmount { get; set; }


        // Navigation Properties
        public Supplier Supplier { get; set; } = null!;

        public Warehouse Warehouse { get; set; } = null!;

        public Quotation? Quotation { get; set; }

        public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
            = new List<PurchaseOrderDetail>();

        public ICollection<GoodsReceipt> GoodsReceipts { get; set; }
            = new List<GoodsReceipt>();

        public ICollection<PurchaseOrderRequisitionDetail> PurchaseOrderRequisitionDetails { get; set; }
            = new List<PurchaseOrderRequisitionDetail>();
    }
}

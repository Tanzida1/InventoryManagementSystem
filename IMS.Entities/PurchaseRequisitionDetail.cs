using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class PurchaseRequisitionDetail
    {
        public int PRDetailId { get; set; }

        public int PurchaseRequisitionId { get; set; }

        public int ItemId { get; set; }

        public decimal RequestedQuantity { get; set; }


        // Navigation Properties
        public PurchaseRequisition PurchaseRequisition { get; set; } = null!;

        public Item Item { get; set; } = null!;

        public ICollection<PurchaseOrderRequisitionDetail> PurchaseOrderRequisitionDetails { get; set; }
            = new List<PurchaseOrderRequisitionDetail>();
    }
}


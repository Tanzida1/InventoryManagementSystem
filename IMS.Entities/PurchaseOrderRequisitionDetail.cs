using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class PurchaseOrderRequisitionDetail
    {
        public int PurchaseOrderRequisitionDetailId { get; set; }

        public int PODetailId { get; set; }

        public int PRDetailId { get; set; }

        public decimal AllocatedQuantity { get; set; }


        // Navigation Properties
        public PurchaseOrderDetail PurchaseOrderDetail { get; set; } = null!;

        public PurchaseRequisitionDetail PurchaseRequisitionDetail { get; set; } = null!;
    }
}

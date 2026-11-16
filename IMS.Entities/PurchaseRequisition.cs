using IMS.Entities.Access;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class PurchaseRequisition
    {
        public int PurchaseRequisitionId { get; set; }

        public string PRNumber { get; set; } = string.Empty;

        public int RequestedBy { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public string? Remarks { get; set; }


        // Navigation Properties
        public User User { get; set; } = null!;

        public ICollection<PurchaseRequisitionDetail> PurchaseRequisitionDetails { get; set; }
            = new List<PurchaseRequisitionDetail>();
    }
}

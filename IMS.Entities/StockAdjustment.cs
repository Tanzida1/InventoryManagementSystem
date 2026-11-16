using IMS.Entities.Access;
using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class StockAdjustment
    {
        public int AdjustmentId { get; set; }

        public string AdjustmentNumber { get; set; } = string.Empty;

        public int WarehouseId { get; set; }

        public int RequestedBy { get; set; }

        public int? ApprovedBy { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public DateTime? ApprovedDate { get; set; }

        public string? Remarks { get; set; }


        // Navigation Properties
        public Warehouse Warehouse { get; set; } = null!;

        public User Requester { get; set; } = null!;

        public User? Approver { get; set; }

        public ICollection<StockAdjustmentDetail> StockAdjustmentDetails { get; set; }
            = new List<StockAdjustmentDetail>();
    }
}

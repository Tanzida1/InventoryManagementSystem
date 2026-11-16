using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class AnomalyDetection
    {
        public int AnomalyId { get; set; }

        public int ItemId { get; set; }

        public int WarehouseId { get; set; }

        public int? LedgerId { get; set; }

        public string AnomalyType { get; set; } = string.Empty;

        public string Severity { get; set; } = "Medium";

        public string Status { get; set; } = "Pending";

        public DateTime DetectedAt { get; set; } = DateTime.Now;


        // Navigation Properties
        public Item Item { get; set; } = null!;

        public Warehouse Warehouse { get; set; } = null!;

        public InventoryLedger? InventoryLedger { get; set; }
    }
}

using IMS.Entities.Access;
using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class PhysicalStockCount
    {
        public int CountId { get; set; }

        public string CountNumber { get; set; } = string.Empty;

        public int WarehouseId { get; set; }

        public int CountedBy { get; set; }

        public DateTime CountDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Pending";

        public string? Remarks { get; set; }


        // Navigation Properties
        public Warehouse Warehouse { get; set; } = null!;

        public User User { get; set; } = null!;

        public ICollection<PhysicalStockCountDetail> PhysicalStockCountDetails { get; set; }
            = new List<PhysicalStockCountDetail>();
    }
}

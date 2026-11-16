using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Entities
{
    public class PhysicalStockCountDetail
    {
        public int CountDetailId { get; set; }

        public int CountId { get; set; }

        public int ItemId { get; set; }

        public decimal SystemQuantity { get; set; }

        public decimal CountedQuantity { get; set; }

        public decimal Difference { get; set; }


        // Navigation Properties
        public PhysicalStockCount PhysicalStockCount { get; set; } = null!;

        public Item Item { get; set; } = null!;
    }
}









//Difference = CountedQuantity - SystemQuantity

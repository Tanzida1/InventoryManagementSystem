using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class StockAdjustmentDetail
    {
        public int AdjustmentDetailId { get; set; }

        public int AdjustmentId { get; set; }

        public int ItemId { get; set; }

        public decimal SystemQuantity { get; set; }

        public decimal AdjustedQuantity { get; set; }

        public string Reason { get; set; } = string.Empty;


        // Navigation Properties
        public StockAdjustment StockAdjustment { get; set; } = null!;

        public Item Item { get; set; } = null!;
    }
}

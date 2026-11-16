using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class ReorderRecommendation
    {
        public int RecommendationId { get; set; }

        public int ItemId { get; set; }

        public int ForecastId { get; set; }

        public int WarehouseId { get; set; }

        public decimal CurrentStock { get; set; }

        public decimal RecommendedQuantity { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        // Navigation Properties
        public Item Item { get; set; } = null!;

        public DemandForecast DemandForecast { get; set; } = null!;

        public Warehouse Warehouse { get; set; } = null!;
    }
}

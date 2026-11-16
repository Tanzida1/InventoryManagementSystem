using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Entities
{
    public class DemandForecast
    {
        public int ForecastId { get; set; }

        public int ForecastRunId { get; set; }

        public int ItemId { get; set; }

        public DateTime ForecastDate { get; set; }

        public decimal PredictedDemand { get; set; }


        // Navigation Properties
        public ForecastRun ForecastRun { get; set; } = null!;

        public Item Item { get; set; } = null!;

        public ICollection<ReorderRecommendation> ReorderRecommendations { get; set; }
            = new List<ReorderRecommendation>();
    }
}

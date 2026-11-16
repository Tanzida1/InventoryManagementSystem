using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class AIModelConfiguration
    {
        public int ConfigurationId { get; set; }

        public string ModelName { get; set; } = string.Empty;

        public int ForecastPeriod { get; set; } = 30;

        public int MinimumHistoryMonths { get; set; } = 6;

        public decimal AnomalySensitivity { get; set; } = 0.5m;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}

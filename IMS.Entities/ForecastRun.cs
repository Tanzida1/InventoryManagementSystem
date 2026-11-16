using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class ForecastRun
    {
        public int ForecastRunId { get; set; }

        public int ConfigurationId { get; set; }

        public string ModelName { get; set; } = string.Empty;

        public DateTime RunDate { get; set; } = DateTime.Now;

        public DateTime TrainingPeriodStart { get; set; }

        public DateTime TrainingPeriodEnd { get; set; }

        public string Status { get; set; } = "Pending";


        // Navigation Properties
        public AIModelConfiguration AIModelConfiguration { get; set; } = null!;

        public ICollection<DemandForecast> DemandForecasts { get; set; }
            = new List<DemandForecast>();

        public ICollection<ModelEvaluation> ModelEvaluations { get; set; }
            = new List<ModelEvaluation>();
    }
}


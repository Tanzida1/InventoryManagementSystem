using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class ModelEvaluation
    {
        public int EvaluationId { get; set; }

        public int ForecastRunId { get; set; }

        public decimal MAE { get; set; }

        public decimal RMSE { get; set; }

        public DateTime EvaluationDate { get; set; } = DateTime.Now;


        // Navigation Property
        public ForecastRun ForecastRun { get; set; } = null!;
    }
}

using IMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public  interface IModelEvaluationFacade
    {
        // 1. Get all model evaluations
        Task<List<ModelEvaluation>> GetAllAsync();

        // 2. Get evaluation by ID
        Task<ModelEvaluation?> GetByIdAsync(int evaluationId);

        // 3. Get evaluations by forecast run
        Task<List<ModelEvaluation>> GetByForecastRunIdAsync(int forecastRunId);

        // 4. Add model evaluation
        Task AddAsync(ModelEvaluation evaluation);
    }
}

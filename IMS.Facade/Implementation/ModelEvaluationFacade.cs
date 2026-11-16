using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class ModelEvaluationFacade : IModelEvaluationFacade
    {
        private readonly IModelEvaluationRepository _modelEvaluationRepository;

        public ModelEvaluationFacade(IModelEvaluationRepository modelEvaluationRepository)
        {
            _modelEvaluationRepository = modelEvaluationRepository;
        }

        public async Task<List<ModelEvaluation>> GetAllAsync()
        {
            return await _modelEvaluationRepository.GetAllAsync();
        }

        public async Task<ModelEvaluation?> GetByIdAsync(int evaluationId)
        {
            return await _modelEvaluationRepository.GetByIdAsync(evaluationId);
        }

        public async Task<List<ModelEvaluation>> GetByForecastRunIdAsync(int forecastRunId)
        {
            return await _modelEvaluationRepository.GetByForecastRunIdAsync(forecastRunId);
        }

        public async Task AddAsync(ModelEvaluation evaluation)
        {
            ArgumentNullException.ThrowIfNull(evaluation);
            await _modelEvaluationRepository.AddAsync(evaluation);
        }
    }
}
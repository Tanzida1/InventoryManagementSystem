
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class ModelEvaluationRepository : IModelEvaluationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ModelEvaluationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ModelEvaluation>> GetAllAsync()
        {
            return await _dbContext.ModelEvaluations.ToListAsync();
        }

        public async Task<ModelEvaluation?> GetByIdAsync(int id)
        {
            return await _dbContext.ModelEvaluations.FindAsync(id);
        }

        public async Task<List<ModelEvaluation>> GetByForecastRunIdAsync(int forecastRunId)
        {
            return await _dbContext.ModelEvaluations
                .Where(evaluation => evaluation.ForecastRunId == forecastRunId)
                .ToListAsync();
        }

        public async Task AddAsync(ModelEvaluation modelEvaluation)
        {
            await _dbContext.ModelEvaluations.AddAsync(modelEvaluation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ModelEvaluation modelEvaluation)
        {
            _dbContext.ModelEvaluations.Update(modelEvaluation);
            await _dbContext.SaveChangesAsync();
        }
    }
}

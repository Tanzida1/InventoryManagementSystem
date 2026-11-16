
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class ForecastRunRepository : IForecastRunRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ForecastRunRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all forecast runs
        public async Task<List<ForecastRun>> GetAllAsync()
        {
            return await _dbContext.ForecastRuns
                .OrderByDescending(forecastRun => forecastRun.ForecastRunId)
                .ToListAsync();
        }

        // 2. Get forecast run by ID
        public async Task<ForecastRun?> GetByIdAsync(int forecastRunId)
        {
            return await _dbContext.ForecastRuns
                .FindAsync(forecastRunId);
        }

        // 3. Get runs by configuration
        public async Task<List<ForecastRun>> GetByConfigurationIdAsync(int configurationId)
        {
            return await _dbContext.ForecastRuns
                .Where(forecastRun => forecastRun.ConfigurationId == configurationId)
                .ToListAsync();
        }

        // 4. Add forecast run
        public async Task AddAsync(ForecastRun forecastRun)
        {
            await _dbContext.ForecastRuns.AddAsync(forecastRun);
            await _dbContext.SaveChangesAsync();
        }

        // 5. Update forecast run
        public async Task UpdateAsync(ForecastRun forecastRun)
        {
            _dbContext.ForecastRuns.Update(forecastRun);
            await _dbContext.SaveChangesAsync();
        }
    }
}

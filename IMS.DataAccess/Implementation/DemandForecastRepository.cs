
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class DemandForecastRepository : IDemandForecastRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DemandForecastRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DemandForecast>> GetAllAsync()
        {
            return await _dbContext.DemandForecasts.ToListAsync();
        }

        public async Task<DemandForecast?> GetByIdAsync(int id)
        {
            return await _dbContext.DemandForecasts.FindAsync(id);
        }

        public async Task<List<DemandForecast>> GetByItemIdAsync(int itemId)
        {
            return await _dbContext.DemandForecasts
                .Where(forecast => forecast.ItemId == itemId)
                .ToListAsync();
        }

        public async Task<List<DemandForecast>> GetByForecastRunIdAsync(int forecastRunId)
        {
            return await _dbContext.DemandForecasts
                .Where(forecast => forecast.ForecastRunId == forecastRunId)
                .ToListAsync();
        }

        public async Task AddAsync(DemandForecast demandForecast)
        {
            await _dbContext.DemandForecasts.AddAsync(demandForecast);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(DemandForecast demandForecast)
        {
            _dbContext.DemandForecasts.Update(demandForecast);
            await _dbContext.SaveChangesAsync();
        }
    }
}

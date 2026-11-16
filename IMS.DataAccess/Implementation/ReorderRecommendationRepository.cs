
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class ReorderRecommendationRepository : IReorderRecommendationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ReorderRecommendationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all recommendations
        public async Task<List<ReorderRecommendation>> GetAllAsync()
        {
            return await _dbContext.ReorderRecommendations
                .ToListAsync();
        }

        // 2. Get recommendation by ID
        public async Task<ReorderRecommendation?> GetByIdAsync(int recommendationId)
        {
            return await _dbContext.ReorderRecommendations
                .FindAsync(recommendationId);
        }

        // 3. Get recommendations by item
        public async Task<List<ReorderRecommendation>> GetByItemIdAsync(int itemId)
        {
            return await _dbContext.ReorderRecommendations
                .Where(recommendation => recommendation.ItemId == itemId)
                .ToListAsync();
        }

        // 4. Get recommendations by warehouse
        public async Task<List<ReorderRecommendation>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _dbContext.ReorderRecommendations
                .Where(recommendation => recommendation.WarehouseId == warehouseId)
                .ToListAsync();
        }

        // 5. Get recommendations by forecast
        public async Task<List<ReorderRecommendation>> GetByForecastIdAsync(int forecastId)
        {
            return await _dbContext.ReorderRecommendations
                .Where(recommendation => recommendation.ForecastId == forecastId)
                .ToListAsync();
        }

        // 6. Add recommendation
        public async Task AddAsync(ReorderRecommendation recommendation)
        {
            await _dbContext.ReorderRecommendations.AddAsync(recommendation);
            await _dbContext.SaveChangesAsync();
        }

        // 7. Update recommendation
        public async Task UpdateAsync(ReorderRecommendation recommendation)
        {
            _dbContext.ReorderRecommendations.Update(recommendation);
            await _dbContext.SaveChangesAsync();
        }
    }
}

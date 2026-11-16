
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IReorderRecommendationRepository
    {
        // 1. Get all recommendations
        Task<List<ReorderRecommendation>> GetAllAsync();

        // 2. Get recommendation by ID
        Task<ReorderRecommendation?> GetByIdAsync(int recommendationId);

        // 3. Get recommendations by item
        Task<List<ReorderRecommendation>> GetByItemIdAsync(int itemId);

        // 4. Get recommendations by warehouse
        Task<List<ReorderRecommendation>> GetByWarehouseIdAsync(int warehouseId);

        // 5. Get recommendations by forecast
        Task<List<ReorderRecommendation>> GetByForecastIdAsync(int forecastId);

        // 6. Add recommendation
        Task AddAsync(ReorderRecommendation recommendation);

        // 7. Update recommendation
        Task UpdateAsync(ReorderRecommendation recommendation);
    }
}

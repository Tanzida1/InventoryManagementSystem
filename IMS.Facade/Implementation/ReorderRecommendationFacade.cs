using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class ReorderRecommendationFacade : IReorderRecommendationFacade
    {
        private readonly IReorderRecommendationRepository _reorderRecommendationRepository;

        public ReorderRecommendationFacade(
            IReorderRecommendationRepository reorderRecommendationRepository)
        {
            _reorderRecommendationRepository = reorderRecommendationRepository;
        }

        public async Task<List<ReorderRecommendation>> GetAllAsync()
        {
            return await _reorderRecommendationRepository.GetAllAsync();
        }

        public async Task<ReorderRecommendation?> GetByIdAsync(int recommendationId)
        {
            return await _reorderRecommendationRepository.GetByIdAsync(recommendationId);
        }

        public async Task<List<ReorderRecommendation>> GetByItemIdAsync(int itemId)
        {
            return await _reorderRecommendationRepository.GetByItemIdAsync(itemId);
        }

        public async Task<List<ReorderRecommendation>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _reorderRecommendationRepository.GetByWarehouseIdAsync(warehouseId);
        }

        public async Task<List<ReorderRecommendation>> GetByForecastIdAsync(int forecastId)
        {
            return await _reorderRecommendationRepository.GetByForecastIdAsync(forecastId);
        }

        public async Task AddAsync(ReorderRecommendation recommendation)
        {
            ArgumentNullException.ThrowIfNull(recommendation);
            await _reorderRecommendationRepository.AddAsync(recommendation);
        }

        public async Task UpdateAsync(ReorderRecommendation recommendation)
        {
            ArgumentNullException.ThrowIfNull(recommendation);
            await _reorderRecommendationRepository.UpdateAsync(recommendation);
        }
    }
}
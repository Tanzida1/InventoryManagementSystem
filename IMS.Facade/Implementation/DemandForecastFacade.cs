
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class DemandForecastFacade : IDemandForecastFacade
    {
        private readonly IDemandForecastRepository _demandForecastRepository;

        public DemandForecastFacade(
            IDemandForecastRepository demandForecastRepository)
        {
            _demandForecastRepository = demandForecastRepository;
        }

        public async Task<List<DemandForecast>> GetAllAsync()
        {
            return await _demandForecastRepository.GetAllAsync();
        }

        public async Task<DemandForecast?> GetByIdAsync(int forecastId)
        {
            return await _demandForecastRepository.GetByIdAsync(forecastId);
        }

        public async Task<List<DemandForecast>> GetByForecastRunIdAsync(
            int forecastRunId)
        {
            return await _demandForecastRepository.GetByForecastRunIdAsync(
                forecastRunId);
        }

        public async Task<List<DemandForecast>> GetByItemIdAsync(int itemId)
        {
            return await _demandForecastRepository.GetByItemIdAsync(itemId);
        }

        public async Task AddAsync(DemandForecast demandForecast)
        {
            ArgumentNullException.ThrowIfNull(demandForecast);

            await _demandForecastRepository.AddAsync(demandForecast);
        }
    }
}

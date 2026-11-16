
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class ForecastRunFacade : IForecastRunFacade
    {
        private readonly IForecastRunRepository _forecastRunRepository;

        public ForecastRunFacade(IForecastRunRepository forecastRunRepository)
        {
            _forecastRunRepository = forecastRunRepository;
        }

        public async Task<List<ForecastRun>> GetAllAsync()
        {
            return await _forecastRunRepository.GetAllAsync();
        }

        public async Task<ForecastRun?> GetByIdAsync(int forecastRunId)
        {
            return await _forecastRunRepository.GetByIdAsync(forecastRunId);
        }

        public async Task<List<ForecastRun>> GetByConfigurationIdAsync(
            int configurationId)
        {
            return await _forecastRunRepository.GetByConfigurationIdAsync(
                configurationId);
        }

        public async Task AddAsync(ForecastRun forecastRun)
        {
            ArgumentNullException.ThrowIfNull(forecastRun);

            await _forecastRunRepository.AddAsync(forecastRun);
        }

        public async Task UpdateAsync(ForecastRun forecastRun)
        {
            ArgumentNullException.ThrowIfNull(forecastRun);

            await _forecastRunRepository.UpdateAsync(forecastRun);
        }
    }
}

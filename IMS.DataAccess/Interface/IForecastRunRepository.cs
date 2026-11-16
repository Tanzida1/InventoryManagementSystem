
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IForecastRunRepository
    {
        // 1. Get all forecast runs
        Task<List<ForecastRun>> GetAllAsync();

        // 2. Get forecast run by ID
        Task<ForecastRun?> GetByIdAsync(int forecastRunId);

        // 3. Get runs by configuration
        Task<List<ForecastRun>> GetByConfigurationIdAsync(int configurationId);

        // 4. Add forecast run
        Task AddAsync(ForecastRun forecastRun);

        // 5. Update forecast run
        Task UpdateAsync(ForecastRun forecastRun);
    }
}

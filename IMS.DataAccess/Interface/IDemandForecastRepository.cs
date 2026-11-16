
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IDemandForecastRepository
    {
        // 1. Get all demand forecasts
        Task<List<DemandForecast>> GetAllAsync();

        // 2. Get forecast by ID
        Task<DemandForecast?> GetByIdAsync(int forecastId);

        // 3. Get forecasts by forecast run
        Task<List<DemandForecast>> GetByForecastRunIdAsync(int forecastRunId);

        // 4. Get forecasts by item
        Task<List<DemandForecast>> GetByItemIdAsync(int itemId);

        // 5. Add demand forecast
        Task AddAsync(DemandForecast demandForecast);
    }
}

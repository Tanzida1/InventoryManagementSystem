
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Facade.Interface
{
    public interface IDemandForecastFacade
    {
        Task<List<DemandForecast>> GetAllAsync();

        Task<DemandForecast?> GetByIdAsync(int forecastId);

        Task<List<DemandForecast>> GetByForecastRunIdAsync(int forecastRunId);

        Task<List<DemandForecast>> GetByItemIdAsync(int itemId);

        Task AddAsync(DemandForecast demandForecast);
    }
}

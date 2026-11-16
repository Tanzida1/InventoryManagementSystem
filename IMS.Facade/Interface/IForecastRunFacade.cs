using IMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public  interface IForecastRunFacade
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

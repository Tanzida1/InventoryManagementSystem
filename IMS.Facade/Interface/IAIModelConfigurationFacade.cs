
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Facade.Interface
{
    public interface IAIModelConfigurationFacade
    {
        Task<List<AIModelConfiguration>> GetAllAsync();

        Task<AIModelConfiguration?> GetByIdAsync(int configurationId);

        Task AddAsync(AIModelConfiguration configuration);

        Task UpdateAsync(AIModelConfiguration configuration);
    }
}


using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IAIModelConfigurationRepository
    {
        // 1. Get all AI configurations
        Task<List<AIModelConfiguration>> GetAllAsync();

        // 2. Get configuration by ID
        Task<AIModelConfiguration?> GetByIdAsync(int configurationId);

        // 3. Add AI configuration
        Task AddAsync(AIModelConfiguration configuration);

        // 4. Update AI configuration
        Task UpdateAsync(AIModelConfiguration configuration);
    }
}

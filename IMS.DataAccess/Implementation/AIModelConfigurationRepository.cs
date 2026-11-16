
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class AIModelConfigurationRepository : IAIModelConfigurationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AIModelConfigurationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AIModelConfiguration>> GetAllAsync()
        {
            return await _dbContext.AIModelConfigurations.ToListAsync();
        }

        public async Task<AIModelConfiguration?> GetByIdAsync(int id)
        {
            return await _dbContext.AIModelConfigurations.FindAsync(id);
        }

        public async Task AddAsync(AIModelConfiguration configuration)
        {
            await _dbContext.AIModelConfigurations.AddAsync(configuration);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(AIModelConfiguration configuration)
        {
            _dbContext.AIModelConfigurations.Update(configuration);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            AIModelConfiguration? configuration =
                await _dbContext.AIModelConfigurations.FindAsync(id);

            if (configuration == null)
            {
                return;
            }

            _dbContext.AIModelConfigurations.Remove(configuration);
            await _dbContext.SaveChangesAsync();
        }
    }
}

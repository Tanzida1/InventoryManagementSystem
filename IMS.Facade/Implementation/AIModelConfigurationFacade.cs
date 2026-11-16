using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Implementation
{
        public class AIModelConfigurationFacade : IAIModelConfigurationFacade
        {


            private readonly IAIModelConfigurationRepository _aiModelConfigurationRepository;

            public AIModelConfigurationFacade(IAIModelConfigurationRepository aiModelConfigurationRepository) 
            
            {

                _aiModelConfigurationRepository = aiModelConfigurationRepository;
            }

            public async Task<List<AIModelConfiguration>> GetAllAsync()
            {

                return await _aiModelConfigurationRepository.GetAllAsync();

            }



            public async Task<AIModelConfiguration?> GetByIdAsync(int configurationId)
            {
                return await _aiModelConfigurationRepository.GetByIdAsync(configurationId);
            }

            public async Task AddAsync(AIModelConfiguration configuration)
            {
                ArgumentNullException.ThrowIfNull(configuration);

                await _aiModelConfigurationRepository.AddAsync(configuration);
            }

            public async Task UpdateAsync(AIModelConfiguration configuration)
            {
                ArgumentNullException.ThrowIfNull(configuration);

                await _aiModelConfigurationRepository.UpdateAsync(configuration);
            }



        }


    
}

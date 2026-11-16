
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class AnomalyDetectionFacade : IAnomalyDetectionFacade
    {
        private readonly IAnomalyDetectionRepository _anomalyDetectionRepository;

        public AnomalyDetectionFacade(
            IAnomalyDetectionRepository anomalyDetectionRepository)
        {
            _anomalyDetectionRepository = anomalyDetectionRepository;
        }

        public async Task<List<AnomalyDetection>> GetAllAsync()
        {
            return await _anomalyDetectionRepository.GetAllAsync();
        }

        public async Task<AnomalyDetection?> GetByIdAsync(int anomalyId)
        {
            return await _anomalyDetectionRepository.GetByIdAsync(anomalyId);
        }

        public async Task<List<AnomalyDetection>> GetByItemIdAsync(int itemId)
        {
            return await _anomalyDetectionRepository.GetByItemIdAsync(itemId);
        }

        public async Task<List<AnomalyDetection>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _anomalyDetectionRepository.GetByWarehouseIdAsync(warehouseId);
        }

        public async Task<List<AnomalyDetection>> GetByStatusAsync(string status)
        {
            return await _anomalyDetectionRepository.GetByStatusAsync(status);
        }

        public async Task AddAsync(AnomalyDetection anomaly)
        {
            ArgumentNullException.ThrowIfNull(anomaly);

            await _anomalyDetectionRepository.AddAsync(anomaly);
        }

        public async Task UpdateAsync(AnomalyDetection anomaly)
        {
            ArgumentNullException.ThrowIfNull(anomaly);

            await _anomalyDetectionRepository.UpdateAsync(anomaly);
        }
    }
}

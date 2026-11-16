
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Facade.Interface
{
    public interface IAnomalyDetectionFacade
    {
        Task<List<AnomalyDetection>> GetAllAsync();

        Task<AnomalyDetection?> GetByIdAsync(int anomalyId);

        Task<List<AnomalyDetection>> GetByItemIdAsync(int itemId);

        Task<List<AnomalyDetection>> GetByWarehouseIdAsync(int warehouseId);

        Task<List<AnomalyDetection>> GetByStatusAsync(string status);

        Task AddAsync(AnomalyDetection anomaly);

        Task UpdateAsync(AnomalyDetection anomaly);
    }
}

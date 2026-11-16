
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IAnomalyDetectionRepository
    {
        // 1. Get all detected anomalies
        Task<List<AnomalyDetection>> GetAllAsync();

        // 2. Get anomaly by ID
        Task<AnomalyDetection?> GetByIdAsync(int anomalyId);

        // 3. Get anomalies by item
        Task<List<AnomalyDetection>> GetByItemIdAsync(int itemId);

        // 4. Get anomalies by warehouse
        Task<List<AnomalyDetection>> GetByWarehouseIdAsync(int warehouseId);

        // 5. Get anomalies by status
        Task<List<AnomalyDetection>> GetByStatusAsync(string status);

        // 6. Add anomaly detection
        Task AddAsync(AnomalyDetection anomaly);

        // 7. Update anomaly status
        Task UpdateAsync(AnomalyDetection anomaly);
    }
}


using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class AnomalyDetectionRepository : IAnomalyDetectionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AnomalyDetectionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all detected anomalies
        public async Task<List<AnomalyDetection>> GetAllAsync()
        {
            return await _dbContext.AnomalyDetections
                .ToListAsync();
        }

        // 2. Get anomaly by ID
        public async Task<AnomalyDetection?> GetByIdAsync(int anomalyId)
        {
            return await _dbContext.AnomalyDetections
                .FindAsync(anomalyId);
        }

        // 3. Get anomalies by item
        public async Task<List<AnomalyDetection>> GetByItemIdAsync(int itemId)
        {
            return await _dbContext.AnomalyDetections
                .Where(anomaly => anomaly.ItemId == itemId)
                .ToListAsync();
        }

        // 4. Get anomalies by warehouse
        public async Task<List<AnomalyDetection>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _dbContext.AnomalyDetections
                .Where(anomaly => anomaly.WarehouseId == warehouseId)
                .ToListAsync();
        }

        // 5. Get anomalies by status
        public async Task<List<AnomalyDetection>> GetByStatusAsync(string status)
        {
            return await _dbContext.AnomalyDetections
                .Where(anomaly => anomaly.Status == status)
                .ToListAsync();
        }

        // 6. Add anomaly detection
        public async Task AddAsync(AnomalyDetection anomaly)
        {
            await _dbContext.AnomalyDetections.AddAsync(anomaly);
            await _dbContext.SaveChangesAsync();
        }

        // 7. Update anomaly status
        public async Task UpdateAsync(AnomalyDetection anomaly)
        {
            _dbContext.AnomalyDetections.Update(anomaly);
            await _dbContext.SaveChangesAsync();
        }
    }
}

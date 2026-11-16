
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IStockAdjustmentRepository
    {
        // 1. Get all adjustments
        Task<List<StockAdjustment>> GetAllAsync();

        // 2. Get adjustment by ID
        Task<StockAdjustment?> GetByIdAsync(int adjustmentId);

        // 3. Get adjustments by warehouse
        Task<List<StockAdjustment>> GetByWarehouseIdAsync(int warehouseId);

        // 4. Get adjustments by requester
        Task<List<StockAdjustment>> GetByRequesterIdAsync(int requesterId);

        // 5. Create adjustment request
        Task AddAsync(StockAdjustment stockAdjustment);

        // 6. Update adjustment
        Task UpdateAsync(StockAdjustment stockAdjustment);
    }
}

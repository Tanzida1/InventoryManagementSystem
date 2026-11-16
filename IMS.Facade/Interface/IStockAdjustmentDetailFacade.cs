using IMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public interface IStockAdjustmentDetailFacade
    {
        // 1. Get all adjustment details
        Task<List<StockAdjustmentDetail>> GetAllAsync();

        // 2. Get detail by ID
        Task<StockAdjustmentDetail?> GetByIdAsync(int adjustmentDetailId);

        // 3. Get details by adjustment
        Task<List<StockAdjustmentDetail>> GetByAdjustmentIdAsync(int adjustmentId);

        // 4. Get adjustment details by item
        Task<List<StockAdjustmentDetail>> GetByItemIdAsync(int itemId);

        // 5. Add adjustment detail
        Task AddAsync(StockAdjustmentDetail adjustmentDetail);

        // 6. Update adjustment detail
        Task UpdateAsync(StockAdjustmentDetail adjustmentDetail);
    }
}

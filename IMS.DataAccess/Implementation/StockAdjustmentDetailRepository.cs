
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class StockAdjustmentDetailRepository : IStockAdjustmentDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StockAdjustmentDetailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StockAdjustmentDetail>> GetAllAsync()
        {
            return await _dbContext.StockAdjustmentDetails.ToListAsync();
        }

        public async Task<StockAdjustmentDetail?> GetByIdAsync(int id)
        {
            return await _dbContext.StockAdjustmentDetails.FindAsync(id);
        }

        public async Task<List<StockAdjustmentDetail>> GetByAdjustmentIdAsync(int adjustmentId)
        {
            return await _dbContext.StockAdjustmentDetails
                .Where(detail => detail.AdjustmentId == adjustmentId)
                .ToListAsync();
        }

        public async Task<List<StockAdjustmentDetail>> GetByItemIdAsync(int itemId)
        {
            return await _dbContext.StockAdjustmentDetails
                .Where(detail => detail.ItemId == itemId)
                .ToListAsync();
        }

        public async Task AddAsync(StockAdjustmentDetail stockAdjustmentDetail)
        {
            await _dbContext.StockAdjustmentDetails.AddAsync(stockAdjustmentDetail);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(StockAdjustmentDetail stockAdjustmentDetail)
        {
            _dbContext.StockAdjustmentDetails.Update(stockAdjustmentDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}


using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class StockAdjustmentRepository : IStockAdjustmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StockAdjustmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StockAdjustment>> GetAllAsync()
        {
            return await _dbContext.StockAdjustments.ToListAsync();
        }

        public async Task<StockAdjustment?> GetByIdAsync(int id)
        {
            return await _dbContext.StockAdjustments.FindAsync(id);
        }

        public async Task<List<StockAdjustment>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _dbContext.StockAdjustments
                .Where(adjustment => adjustment.WarehouseId == warehouseId)
                .ToListAsync();
        }



        //Get adjustments by requester

        public async Task<List<StockAdjustment>> GetByRequesterIdAsync(int requesterId)
        {
            return await _dbContext.StockAdjustments
                .Where(adjustment => adjustment.RequestedBy == requesterId)
                .ToListAsync();
        }





        public async Task AddAsync(StockAdjustment stockAdjustment)
        {
            await _dbContext.StockAdjustments.AddAsync(stockAdjustment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(StockAdjustment stockAdjustment)
        {
            _dbContext.StockAdjustments.Update(stockAdjustment);
            await _dbContext.SaveChangesAsync();
        }
    }
}

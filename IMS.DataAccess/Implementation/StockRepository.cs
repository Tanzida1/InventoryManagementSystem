
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Implementation
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StockRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all stocks
        public async Task<List<Stock>> GetAllAsync()
        {
            return await _dbContext.Stocks
                .OrderByDescending(stock => stock.StockId)
                .ToListAsync();
        }

        // 2. Get stock by ID
        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _dbContext.Stocks.FindAsync(id);
        }

        // 3. Get stocks by warehouse ID
        public async Task<List<Stock>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _dbContext.Stocks
                .Where(stock => stock.WarehouseId == warehouseId)
                .ToListAsync();
        }

        // 4. Get stocks by item ID
        public async Task<List<Stock>> GetByItemIdAsync(int itemId)
        {
            return await _dbContext.Stocks
                .Where(stock => stock.ItemId == itemId)
                .ToListAsync();
        }

        // 5. Get stock by item and warehouse
        public async Task<Stock?> GetByItemAndWarehouseAsync(
            int itemId, int warehouseId)
        {
            return await _dbContext.Stocks
                .FirstOrDefaultAsync(stock =>
                    stock.ItemId == itemId &&
                    stock.WarehouseId == warehouseId);
        }

        // 6. Add stock
        public async Task AddAsync(Stock stock)
        {
            await _dbContext.Stocks.AddAsync(stock);
            await _dbContext.SaveChangesAsync();
        }

        // 7. Update stock
        public async Task UpdateAsync(Stock stock)
        {
            _dbContext.Stocks.Update(stock);
            await _dbContext.SaveChangesAsync();
        }
    }
}

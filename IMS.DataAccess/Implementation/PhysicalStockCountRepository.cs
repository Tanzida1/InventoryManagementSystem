using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class PhysicalStockCountRepository : IPhysicalStockCountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PhysicalStockCountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all physical stock counts
        public async Task<List<PhysicalStockCount>> GetAllAsync()
        {
            return await _dbContext.PhysicalStockCounts
                .ToListAsync();
        }

        // 2. Get count by ID
        public async Task<PhysicalStockCount?> GetByIdAsync(int id)
        {
            return await _dbContext.PhysicalStockCounts
                .FindAsync(id);
        }

        // 3. Get counts by warehouse
        public async Task<List<PhysicalStockCount>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _dbContext.PhysicalStockCounts
                .Where(count => count.WarehouseId == warehouseId)
                .ToListAsync();
        }

        // 4. Get counts by user
        public async Task<List<PhysicalStockCount>> GetByCountedByAsync(int userId)
        {
            return await _dbContext.PhysicalStockCounts
                .Where(count => count.CountedBy == userId)
                .ToListAsync();
        }

        // 5. Create physical stock count
        public async Task AddAsync(PhysicalStockCount physicalStockCount)
        {
            await _dbContext.PhysicalStockCounts.AddAsync(physicalStockCount);
            await _dbContext.SaveChangesAsync();
        }

        // 6. Update physical stock count
        public async Task UpdateAsync(PhysicalStockCount physicalStockCount)
        {
            _dbContext.PhysicalStockCounts.Update(physicalStockCount);
            await _dbContext.SaveChangesAsync();
        }
    }
}
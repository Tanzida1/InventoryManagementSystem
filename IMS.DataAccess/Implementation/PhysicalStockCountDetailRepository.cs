
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class PhysicalStockCountDetailRepository : IPhysicalStockCountDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PhysicalStockCountDetailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all physical count details
        public async Task<List<PhysicalStockCountDetail>> GetAllAsync()
        {
            return await _dbContext.PhysicalStockCountDetails.ToListAsync();
        }

        // 2. Get detail by ID
        public async Task<PhysicalStockCountDetail?> GetByIdAsync(int id)
        {
            return await _dbContext.PhysicalStockCountDetails.FindAsync(id);
        }

        // 3. Get details by physical count ID
        public async Task<List<PhysicalStockCountDetail>> GetByCountIdAsync(int countId)
        {
            return await _dbContext.PhysicalStockCountDetails
                .Where(detail => detail.CountId == countId)
                .ToListAsync();
        }

        // 4. Get details by item ID
        public async Task<List<PhysicalStockCountDetail>> GetByItemIdAsync(int itemId)
        {
            return await _dbContext.PhysicalStockCountDetails
                .Where(detail => detail.ItemId == itemId)
                .ToListAsync();
        }

        // 5. Add physical count detail
        public async Task AddAsync(PhysicalStockCountDetail physicalStockCountDetail)
        {
            await _dbContext.PhysicalStockCountDetails.AddAsync(physicalStockCountDetail);
            await _dbContext.SaveChangesAsync();
        }

        // 6. Update physical count detail
        public async Task UpdateAsync(PhysicalStockCountDetail physicalStockCountDetail)
        {
            _dbContext.PhysicalStockCountDetails.Update(physicalStockCountDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}

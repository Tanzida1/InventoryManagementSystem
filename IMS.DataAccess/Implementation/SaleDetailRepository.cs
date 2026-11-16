
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class SaleDetailRepository : ISaleDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SaleDetailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all sale details
        public async Task<List<SaleDetail>> GetAllAsync()
        {
            return await _dbContext.SaleDetails.ToListAsync();
        }

        // 2. Get sale detail by ID
        public async Task<SaleDetail?> GetByIdAsync(int saleDetailId)
        {
            return await _dbContext.SaleDetails.FindAsync(saleDetailId);
        }

        // 3. Get details by sale
        public async Task<List<SaleDetail>> GetBySaleIdAsync(int saleId)
        {
            return await _dbContext.SaleDetails
                .Where(detail => detail.SaleId == saleId)
                .ToListAsync();
        }

        // 4. Get details by item
        public async Task<List<SaleDetail>> GetByItemIdAsync(int itemId)
        {
            return await _dbContext.SaleDetails
                .Where(detail => detail.ItemId == itemId)
                .ToListAsync();
        }

        // 5. Add sale detail
        public async Task AddAsync(SaleDetail saleDetail)
        {
            await _dbContext.SaleDetails.AddAsync(saleDetail);
            await _dbContext.SaveChangesAsync();
        }

        // 6. Update sale detail
        public async Task UpdateAsync(SaleDetail saleDetail)
        {
            _dbContext.SaleDetails.Update(saleDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}


using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SaleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all sales
        public async Task<List<Sale>> GetAllAsync()
        {
            return await _dbContext.Sales.ToListAsync();
        }

        // 2. Get sale by ID
        public async Task<Sale?> GetByIdAsync(int saleId)
        {
            return await _dbContext.Sales.FindAsync(saleId);
        }

        // 3. Get sales by warehouse
        public async Task<List<Sale>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _dbContext.Sales
                .Where(sale => sale.WarehouseId == warehouseId)
                .ToListAsync();
        }

        // 4. Get sales by user (Sales Officer)
        public async Task<List<Sale>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.Sales
                .Where(sale => sale.SalesOfficerId == userId)
                .ToListAsync();
        }

        // 5. Create new sale
        public async Task AddAsync(Sale sale)
        {
            await _dbContext.Sales.AddAsync(sale);
            await _dbContext.SaveChangesAsync();
        }

        // 6. Update sale
        public async Task UpdateAsync(Sale sale)
        {
            _dbContext.Sales.Update(sale);
            await _dbContext.SaveChangesAsync();
        }
    }
}

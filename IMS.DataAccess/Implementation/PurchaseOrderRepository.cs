using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PurchaseOrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PurchaseOrder>> GetAllAsync()
        {
            return await _dbContext.PurchaseOrders.ToListAsync();
        }

        public async Task<PurchaseOrder?> GetByIdAsync(int id)
        {
            return await _dbContext.PurchaseOrders.FindAsync(id);
        }

        public async Task<List<PurchaseOrder>> GetBySupplierIdAsync(int supplierId)
        {
            return await _dbContext.PurchaseOrders
                .Where(order => order.SupplierId == supplierId)
                .ToListAsync();
        }

        public async Task<List<PurchaseOrder>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _dbContext.PurchaseOrders
                .Where(order => order.WarehouseId == warehouseId)
                .ToListAsync();
        }

        public async Task AddAsync(PurchaseOrder purchaseOrder)
        {
            await _dbContext.PurchaseOrders.AddAsync(purchaseOrder);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PurchaseOrder purchaseOrder)
        {
            _dbContext.PurchaseOrders.Update(purchaseOrder);
            await _dbContext.SaveChangesAsync();
        }
    }
}
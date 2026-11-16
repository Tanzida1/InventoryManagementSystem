using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class PurchaseOrderDetailRepository : IPurchaseOrderDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PurchaseOrderDetailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PurchaseOrderDetail>> GetAllAsync()
        {
            return await _dbContext.PurchaseOrderDetails.ToListAsync();
        }

        public async Task<PurchaseOrderDetail?> GetByIdAsync(int id)
        {
            return await _dbContext.PurchaseOrderDetails.FindAsync(id);
        }

        public async Task<List<PurchaseOrderDetail>> GetByPurchaseOrderIdAsync(int purchaseOrderId)
        {
            return await _dbContext.PurchaseOrderDetails
                .Where(detail => detail.PurchaseOrderId == purchaseOrderId)
                .ToListAsync();
        }

        public async Task<List<PurchaseOrderDetail>> GetByItemIdAsync(int itemId)
        {
            return await _dbContext.PurchaseOrderDetails
                .Where(detail => detail.ItemId == itemId)
                .ToListAsync();
        }

        public async Task AddAsync(PurchaseOrderDetail purchaseOrderDetail)
        {
            await _dbContext.PurchaseOrderDetails.AddAsync(purchaseOrderDetail);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PurchaseOrderDetail purchaseOrderDetail)
        {
            _dbContext.PurchaseOrderDetails.Update(purchaseOrderDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}
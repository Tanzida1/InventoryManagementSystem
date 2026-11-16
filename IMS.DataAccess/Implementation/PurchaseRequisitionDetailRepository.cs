using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class PurchaseRequisitionDetailRepository : IPurchaseRequisitionDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PurchaseRequisitionDetailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PurchaseRequisitionDetail>> GetAllAsync()
        {
            return await _dbContext.PurchaseRequisitionDetails.ToListAsync();
        }

        public async Task<PurchaseRequisitionDetail?> GetByIdAsync(int purchaseRequisitionDetailId)
        {
            return await _dbContext.PurchaseRequisitionDetails.FindAsync(purchaseRequisitionDetailId);
        }

        public async Task<List<PurchaseRequisitionDetail>> GetByPurchaseRequisitionIdAsync(int purchaseRequisitionId)
        {
            return await _dbContext.PurchaseRequisitionDetails
                .Where(detail => detail.PurchaseRequisitionId == purchaseRequisitionId)
                .ToListAsync();
        }

        public async Task<List<PurchaseRequisitionDetail>> GetByItemIdAsync(int itemId)
        {
            return await _dbContext.PurchaseRequisitionDetails
                .Where(detail => detail.ItemId == itemId)
                .ToListAsync();
        }

        public async Task AddAsync(PurchaseRequisitionDetail purchaseRequisitionDetail)
        {
            await _dbContext.PurchaseRequisitionDetails.AddAsync(purchaseRequisitionDetail);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PurchaseRequisitionDetail purchaseRequisitionDetail)
        {
            _dbContext.PurchaseRequisitionDetails.Update(purchaseRequisitionDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}
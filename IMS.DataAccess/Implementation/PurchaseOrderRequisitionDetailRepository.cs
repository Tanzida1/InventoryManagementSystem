using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class PurchaseOrderRequisitionDetailRepository : IPurchaseOrderRequisitionDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PurchaseOrderRequisitionDetailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PurchaseOrderRequisitionDetail>> GetAllAsync()
        {
            return await _dbContext.PurchaseOrderRequisitionDetails.ToListAsync();
        }

        public async Task<PurchaseOrderRequisitionDetail?> GetByIdAsync(int id)
        {
            return await _dbContext.PurchaseOrderRequisitionDetails.FindAsync(id);
        }

        public async Task<List<PurchaseOrderRequisitionDetail>> GetByPODetailIdAsync(int poDetailId)
        {
            return await _dbContext.PurchaseOrderRequisitionDetails
                .Where(detail => detail.PODetailId == poDetailId)
                .ToListAsync();
        }

        public async Task<List<PurchaseOrderRequisitionDetail>> GetByPRDetailIdAsync(int prDetailId)
        {
            return await _dbContext.PurchaseOrderRequisitionDetails
                .Where(detail => detail.PRDetailId == prDetailId)
                .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            PurchaseOrderRequisitionDetail? purchaseOrderRequisitionDetail =
                await _dbContext.PurchaseOrderRequisitionDetails.FindAsync(id);

            if (purchaseOrderRequisitionDetail == null)
            {
                return;
            }

            _dbContext.PurchaseOrderRequisitionDetails.Remove(purchaseOrderRequisitionDetail);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddAsync(PurchaseOrderRequisitionDetail purchaseOrderRequisitionDetail)
        {
            await _dbContext.PurchaseOrderRequisitionDetails.AddAsync(purchaseOrderRequisitionDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}
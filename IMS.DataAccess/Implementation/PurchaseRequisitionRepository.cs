using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class PurchaseRequisitionRepository : IPurchaseRequisitionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PurchaseRequisitionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PurchaseRequisition>> GetAllAsync()
        {
            return await _dbContext.PurchaseRequisitions.ToListAsync();
        }

        public async Task<PurchaseRequisition?> GetByIdAsync(int id)
        {
            return await _dbContext.PurchaseRequisitions.FindAsync(id);
        }

        public async Task AddAsync(PurchaseRequisition purchaseRequisition)
        {
            await _dbContext.PurchaseRequisitions.AddAsync(purchaseRequisition);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PurchaseRequisition purchaseRequisition)
        {
            _dbContext.PurchaseRequisitions.Update(purchaseRequisition);
            await _dbContext.SaveChangesAsync();
        }
    }
}
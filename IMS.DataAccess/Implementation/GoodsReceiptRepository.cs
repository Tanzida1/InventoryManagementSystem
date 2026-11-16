using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class GoodsReceiptRepository : IGoodsReceiptRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GoodsReceiptRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GoodsReceipt>> GetAllAsync()
        {
            return await _dbContext.GoodsReceipts.ToListAsync();
        }

        public async Task<GoodsReceipt?> GetByIdAsync(int id)
        {
            return await _dbContext.GoodsReceipts.FindAsync(id);
        }

        public async Task<List<GoodsReceipt>> GetByPurchaseOrderIdAsync(int purchaseOrderId)
        {
            return await _dbContext.GoodsReceipts
                .Where(receipt => receipt.PurchaseOrderId == purchaseOrderId)
                .ToListAsync();
        }

        public async Task AddAsync(GoodsReceipt goodsReceipt)
        {
            await _dbContext.GoodsReceipts.AddAsync(goodsReceipt);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(GoodsReceipt goodsReceipt)
        {
            _dbContext.GoodsReceipts.Update(goodsReceipt);
            await _dbContext.SaveChangesAsync();
        }
    }
}
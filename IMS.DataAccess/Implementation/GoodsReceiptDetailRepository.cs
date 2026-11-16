using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class GoodsReceiptDetailRepository : IGoodsReceiptDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GoodsReceiptDetailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GoodsReceiptDetail>> GetAllAsync()
        {
            return await _dbContext.GoodsReceiptDetails.ToListAsync();
        }

        public async Task<GoodsReceiptDetail?> GetByIdAsync(int id)
        {
            return await _dbContext.GoodsReceiptDetails.FindAsync(id);
        }

        public async Task<List<GoodsReceiptDetail>> GetByGoodsReceiptIdAsync(int goodsReceiptId)
        {
            return await _dbContext.GoodsReceiptDetails
                .Where(detail => detail.GoodsReceiptId == goodsReceiptId)
                .ToListAsync();
        }

        public async Task<List<GoodsReceiptDetail>> GetByPODetailIdAsync(int poDetailId)
        {
            return await _dbContext.GoodsReceiptDetails
                .Where(detail => detail.PODetailId == poDetailId)
                .ToListAsync();
        }

        public async Task AddAsync(GoodsReceiptDetail goodsReceiptDetail)
        {
            await _dbContext.GoodsReceiptDetails.AddAsync(goodsReceiptDetail);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(GoodsReceiptDetail goodsReceiptDetail)
        {
            _dbContext.GoodsReceiptDetails.Update(goodsReceiptDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}
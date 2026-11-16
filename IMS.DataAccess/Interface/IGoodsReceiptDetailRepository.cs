
using IMS.Entities;

namespace IMS.DataAccess.Interface
{
    public interface IGoodsReceiptDetailRepository
    {
        Task<List<GoodsReceiptDetail>> GetAllAsync();

        Task<GoodsReceiptDetail?> GetByIdAsync(int id);

        Task<List<GoodsReceiptDetail>> GetByGoodsReceiptIdAsync(int goodsReceiptId);

        Task<List<GoodsReceiptDetail>> GetByPODetailIdAsync(int poDetailId);

        Task AddAsync(GoodsReceiptDetail goodsReceiptDetail);

        Task UpdateAsync(GoodsReceiptDetail goodsReceiptDetail);
    }
}

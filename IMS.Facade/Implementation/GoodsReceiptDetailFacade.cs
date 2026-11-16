
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class GoodsReceiptDetailFacade : IGoodsReceiptDetailFacade
    {
        private readonly IGoodsReceiptDetailRepository _goodsReceiptDetailRepository;

        public GoodsReceiptDetailFacade(
            IGoodsReceiptDetailRepository goodsReceiptDetailRepository)
        {
            _goodsReceiptDetailRepository = goodsReceiptDetailRepository;
        }

        public async Task<List<GoodsReceiptDetail>> GetAllAsync()
        {
            return await _goodsReceiptDetailRepository.GetAllAsync();
        }

        public async Task<GoodsReceiptDetail?> GetByIdAsync(int id)
        {
            return await _goodsReceiptDetailRepository.GetByIdAsync(id);
        }

        public async Task<List<GoodsReceiptDetail>> GetByGoodsReceiptIdAsync(
            int goodsReceiptId)
        {
            return await _goodsReceiptDetailRepository
                .GetByGoodsReceiptIdAsync(goodsReceiptId);
        }

        public async Task<List<GoodsReceiptDetail>> GetByPODetailIdAsync(
            int poDetailId)
        {
            return await _goodsReceiptDetailRepository
                .GetByPODetailIdAsync(poDetailId);
        }

        public async Task AddAsync(GoodsReceiptDetail goodsReceiptDetail)
        {
            ArgumentNullException.ThrowIfNull(goodsReceiptDetail);

            await _goodsReceiptDetailRepository.AddAsync(goodsReceiptDetail);
        }

        public async Task UpdateAsync(GoodsReceiptDetail goodsReceiptDetail)
        {
            ArgumentNullException.ThrowIfNull(goodsReceiptDetail);

            await _goodsReceiptDetailRepository.UpdateAsync(goodsReceiptDetail);
        }
    }
}

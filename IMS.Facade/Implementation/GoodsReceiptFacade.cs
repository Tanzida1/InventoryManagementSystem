
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class GoodsReceiptFacade : IGoodsReceiptFacade
    {
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;

        public GoodsReceiptFacade(IGoodsReceiptRepository goodsReceiptRepository)
        {
            _goodsReceiptRepository = goodsReceiptRepository;
        }

        public async Task<List<GoodsReceipt>> GetAllAsync()
        {
            return await _goodsReceiptRepository.GetAllAsync();
        }

        public async Task<GoodsReceipt?> GetByIdAsync(int goodsReceiptId)
        {
            return await _goodsReceiptRepository.GetByIdAsync(goodsReceiptId);
        }

        public async Task<List<GoodsReceipt>> GetByPurchaseOrderIdAsync(
            int purchaseOrderId)
        {
            return await _goodsReceiptRepository.GetByPurchaseOrderIdAsync(
                purchaseOrderId);
        }

        public async Task AddAsync(GoodsReceipt goodsReceipt)
        {
            ArgumentNullException.ThrowIfNull(goodsReceipt);

            await _goodsReceiptRepository.AddAsync(goodsReceipt);
        }

        public async Task UpdateAsync(GoodsReceipt goodsReceipt)
        {
            ArgumentNullException.ThrowIfNull(goodsReceipt);

            await _goodsReceiptRepository.UpdateAsync(goodsReceipt);
        }
    }
}

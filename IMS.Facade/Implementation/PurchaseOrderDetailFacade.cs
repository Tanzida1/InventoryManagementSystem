using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class PurchaseOrderDetailFacade : IPurchaseOrderDetailFacade
    {
        private readonly IPurchaseOrderDetailRepository _purchaseOrderDetailRepository;

        public PurchaseOrderDetailFacade(IPurchaseOrderDetailRepository purchaseOrderDetailRepository)
        {
            _purchaseOrderDetailRepository = purchaseOrderDetailRepository;
        }

        public async Task<List<PurchaseOrderDetail>> GetAllAsync()
        {
            return await _purchaseOrderDetailRepository.GetAllAsync();
        }

        public async Task<PurchaseOrderDetail?> GetByIdAsync(int id)
        {
            return await _purchaseOrderDetailRepository.GetByIdAsync(id);
        }

        public async Task<List<PurchaseOrderDetail>> GetByPurchaseOrderIdAsync(int purchaseOrderId)
        {
            return await _purchaseOrderDetailRepository.GetByPurchaseOrderIdAsync(purchaseOrderId);
        }

        public async Task<List<PurchaseOrderDetail>> GetByItemIdAsync(int itemId)
        {
            return await _purchaseOrderDetailRepository.GetByItemIdAsync(itemId);
        }

        public async Task AddAsync(PurchaseOrderDetail purchaseOrderDetail)
        {
            ArgumentNullException.ThrowIfNull(purchaseOrderDetail);
            await _purchaseOrderDetailRepository.AddAsync(purchaseOrderDetail);
        }

        public async Task UpdateAsync(PurchaseOrderDetail purchaseOrderDetail)
        {
            ArgumentNullException.ThrowIfNull(purchaseOrderDetail);
            await _purchaseOrderDetailRepository.UpdateAsync(purchaseOrderDetail);
        }
    }
}
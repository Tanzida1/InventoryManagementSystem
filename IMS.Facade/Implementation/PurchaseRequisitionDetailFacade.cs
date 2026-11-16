using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class PurchaseRequisitionDetailFacade : IPurchaseRequisitionDetailFacade
    {
        private readonly IPurchaseRequisitionDetailRepository _purchaseRequisitionDetailRepository;

        public PurchaseRequisitionDetailFacade(
            IPurchaseRequisitionDetailRepository purchaseRequisitionDetailRepository)
        {
            _purchaseRequisitionDetailRepository = purchaseRequisitionDetailRepository;
        }

        public async Task<List<PurchaseRequisitionDetail>> GetAllAsync()
        {
            return await _purchaseRequisitionDetailRepository.GetAllAsync();
        }

        public async Task<PurchaseRequisitionDetail?> GetByIdAsync(int purchaseRequisitionDetailId)
        {
            return await _purchaseRequisitionDetailRepository.GetByIdAsync(purchaseRequisitionDetailId);
        }

        public async Task<List<PurchaseRequisitionDetail>> GetByPurchaseRequisitionIdAsync(int purchaseRequisitionId)
        {
            return await _purchaseRequisitionDetailRepository.GetByPurchaseRequisitionIdAsync(purchaseRequisitionId);
        }

        public async Task<List<PurchaseRequisitionDetail>> GetByItemIdAsync(int itemId)
        {
            return await _purchaseRequisitionDetailRepository.GetByItemIdAsync(itemId);
        }

        public async Task AddAsync(PurchaseRequisitionDetail purchaseRequisitionDetail)
        {
            ArgumentNullException.ThrowIfNull(purchaseRequisitionDetail);
            await _purchaseRequisitionDetailRepository.AddAsync(purchaseRequisitionDetail);
        }

        public async Task UpdateAsync(PurchaseRequisitionDetail purchaseRequisitionDetail)
        {
            ArgumentNullException.ThrowIfNull(purchaseRequisitionDetail);
            await _purchaseRequisitionDetailRepository.UpdateAsync(purchaseRequisitionDetail);
        }
    }
}
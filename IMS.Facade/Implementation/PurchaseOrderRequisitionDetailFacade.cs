using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class PurchaseOrderRequisitionDetailFacade : IPurchaseOrderRequisitionDetailFacade
    {
        private readonly IPurchaseOrderRequisitionDetailRepository _purchaseOrderRequisitionDetailRepository;

        public PurchaseOrderRequisitionDetailFacade(
            IPurchaseOrderRequisitionDetailRepository purchaseOrderRequisitionDetailRepository)
        {
            _purchaseOrderRequisitionDetailRepository = purchaseOrderRequisitionDetailRepository;
        }

        public async Task<List<PurchaseOrderRequisitionDetail>> GetAllAsync()
        {
            return await _purchaseOrderRequisitionDetailRepository.GetAllAsync();
        }

        public async Task<PurchaseOrderRequisitionDetail?> GetByIdAsync(int id)
        {
            return await _purchaseOrderRequisitionDetailRepository.GetByIdAsync(id);
        }

        public async Task<List<PurchaseOrderRequisitionDetail>> GetByPODetailIdAsync(int poDetailId)
        {
            return await _purchaseOrderRequisitionDetailRepository.GetByPODetailIdAsync(poDetailId);
        }

        public async Task<List<PurchaseOrderRequisitionDetail>> GetByPRDetailIdAsync(int prDetailId)
        {
            return await _purchaseOrderRequisitionDetailRepository.GetByPRDetailIdAsync(prDetailId);
        }

        public async Task AddAsync(PurchaseOrderRequisitionDetail mapping)
        {
            ArgumentNullException.ThrowIfNull(mapping);
            await _purchaseOrderRequisitionDetailRepository.AddAsync(mapping);
        }

        public async Task DeleteAsync(int id)
        {
            await _purchaseOrderRequisitionDetailRepository.DeleteAsync(id);
        }
    }
}
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class PurchaseRequisitionFacade : IPurchaseRequisitionFacade
    {
        private readonly IPurchaseRequisitionRepository _purchaseRequisitionRepository;

        public PurchaseRequisitionFacade(IPurchaseRequisitionRepository purchaseRequisitionRepository)
        {
            _purchaseRequisitionRepository = purchaseRequisitionRepository;
        }

        public async Task<List<PurchaseRequisition>> GetAllAsync()
        {
            return await _purchaseRequisitionRepository.GetAllAsync();
        }

        public async Task<PurchaseRequisition?> GetByIdAsync(int id)
        {
            return await _purchaseRequisitionRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(PurchaseRequisition purchaseRequisition)
        {
            ArgumentNullException.ThrowIfNull(purchaseRequisition);
            await _purchaseRequisitionRepository.AddAsync(purchaseRequisition);
        }

        public async Task UpdateAsync(PurchaseRequisition purchaseRequisition)
        {
            ArgumentNullException.ThrowIfNull(purchaseRequisition);
            await _purchaseRequisitionRepository.UpdateAsync(purchaseRequisition);
        }
    }
}
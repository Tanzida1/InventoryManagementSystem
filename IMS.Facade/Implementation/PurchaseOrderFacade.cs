using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class PurchaseOrderFacade : IPurchaseOrderFacade
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderFacade(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<List<PurchaseOrder>> GetAllAsync()
        {
            return await _purchaseOrderRepository.GetAllAsync();
        }

        public async Task<PurchaseOrder?> GetByIdAsync(int id)
        {
            return await _purchaseOrderRepository.GetByIdAsync(id);
        }

        public async Task<List<PurchaseOrder>> GetBySupplierIdAsync(int supplierId)
        {
            return await _purchaseOrderRepository.GetBySupplierIdAsync(supplierId);
        }

        public async Task<List<PurchaseOrder>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _purchaseOrderRepository.GetByWarehouseIdAsync(warehouseId);
        }

        public async Task AddAsync(PurchaseOrder purchaseOrder)
        {
            ArgumentNullException.ThrowIfNull(purchaseOrder);
            await _purchaseOrderRepository.AddAsync(purchaseOrder);
        }

        public async Task UpdateAsync(PurchaseOrder purchaseOrder)
        {
            ArgumentNullException.ThrowIfNull(purchaseOrder);
            await _purchaseOrderRepository.UpdateAsync(purchaseOrder);
        }
    }
}
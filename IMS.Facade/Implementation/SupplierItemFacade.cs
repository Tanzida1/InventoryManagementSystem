using IMS.DataAccess.Interface;
using IMS.Entities.Inventory;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class SupplierItemFacade : ISupplierItemFacade
    {
        private readonly ISupplierItemRepository _supplierItemRepository;

        public SupplierItemFacade(ISupplierItemRepository supplierItemRepository)
        {
            _supplierItemRepository = supplierItemRepository;
        }

        public async Task<List<SupplierItem>> GetAllAsync()
        {
            return await _supplierItemRepository.GetAllAsync();
        }

        public async Task<SupplierItem?> GetByIdAsync(int supplierItemId)
        {
            return await _supplierItemRepository.GetByIdAsync(supplierItemId);
        }

        public async Task<List<SupplierItem>> GetBySupplierIdAsync(int supplierId)
        {
            return await _supplierItemRepository.GetBySupplierIdAsync(supplierId);
        }

        public async Task AddAsync(SupplierItem supplierItem)
        {
            ArgumentNullException.ThrowIfNull(supplierItem);
            await _supplierItemRepository.AddAsync(supplierItem);
        }

        public async Task UpdateAsync(SupplierItem supplierItem)
        {
            ArgumentNullException.ThrowIfNull(supplierItem);
            await _supplierItemRepository.UpdateAsync(supplierItem);
        }

        public async Task DeleteAsync(int supplierItemId)
        {
            await _supplierItemRepository.DeleteAsync(supplierItemId);
        }
    }
}
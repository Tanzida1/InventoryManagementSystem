using IMS.DataAccess.Interface;
using IMS.Entities.Inventory;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class SupplierFacade : ISupplierFacade
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierFacade(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _supplierRepository.GetAllAsync();
        }

        public async Task<Supplier?> GetByIdAsync(int supplierId)
        {
            return await _supplierRepository.GetByIdAsync(supplierId);
        }

        public async Task AddAsync(Supplier supplier)
        {
            ArgumentNullException.ThrowIfNull(supplier);
            await _supplierRepository.AddAsync(supplier);
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            ArgumentNullException.ThrowIfNull(supplier);
            await _supplierRepository.UpdateAsync(supplier);
        }

        public async Task DeleteAsync(int supplierId)
        {
            await _supplierRepository.DeleteAsync(supplierId);
        }
    }
}
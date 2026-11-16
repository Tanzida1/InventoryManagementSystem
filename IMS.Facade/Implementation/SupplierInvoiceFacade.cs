using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class SupplierInvoiceFacade : ISupplierInvoiceFacade
    {
        private readonly ISupplierInvoiceRepository _supplierInvoiceRepository;

        public SupplierInvoiceFacade(ISupplierInvoiceRepository supplierInvoiceRepository)
        {
            _supplierInvoiceRepository = supplierInvoiceRepository;
        }

        public async Task<List<SupplierInvoice>> GetAllAsync()
        {
            return await _supplierInvoiceRepository.GetAllAsync();
        }

        public async Task<SupplierInvoice?> GetByIdAsync(int supplierInvoiceId)
        {
            return await _supplierInvoiceRepository.GetByIdAsync(supplierInvoiceId);
        }

        public async Task<List<SupplierInvoice>> GetBySupplierIdAsync(int supplierId)
        {
            return await _supplierInvoiceRepository.GetBySupplierIdAsync(supplierId);
        }

        public async Task AddAsync(SupplierInvoice supplierInvoice)
        {
            ArgumentNullException.ThrowIfNull(supplierInvoice);
            await _supplierInvoiceRepository.AddAsync(supplierInvoice);
        }

        public async Task UpdateAsync(SupplierInvoice supplierInvoice)
        {
            ArgumentNullException.ThrowIfNull(supplierInvoice);
            await _supplierInvoiceRepository.UpdateAsync(supplierInvoice);
        }
    }
}
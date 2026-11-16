using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class SupplierInvoiceDetailFacade : ISupplierInvoiceDetailFacade
    {
        private readonly ISupplierInvoiceDetailRepository _supplierInvoiceDetailRepository;

        public SupplierInvoiceDetailFacade(ISupplierInvoiceDetailRepository supplierInvoiceDetailRepository)
        {
            _supplierInvoiceDetailRepository = supplierInvoiceDetailRepository;
        }

        public async Task<List<SupplierInvoiceDetail>> GetAllAsync()
        {
            return await _supplierInvoiceDetailRepository.GetAllAsync();
        }

        public async Task<SupplierInvoiceDetail?> GetByIdAsync(int supplierInvoiceDetailId)
        {
            return await _supplierInvoiceDetailRepository.GetByIdAsync(supplierInvoiceDetailId);
        }

        public async Task<List<SupplierInvoiceDetail>> GetBySupplierInvoiceIdAsync(int supplierInvoiceId)
        {
            return await _supplierInvoiceDetailRepository.GetBySupplierInvoiceIdAsync(supplierInvoiceId);
        }

        public async Task<List<SupplierInvoiceDetail>> GetByPurchaseOrderDetailIdAsync(int poDetailId)
        {
            return await _supplierInvoiceDetailRepository.GetByPurchaseOrderDetailIdAsync(poDetailId);
        }

        public async Task AddAsync(SupplierInvoiceDetail supplierInvoiceDetail)
        {
            ArgumentNullException.ThrowIfNull(supplierInvoiceDetail);
            await _supplierInvoiceDetailRepository.AddAsync(supplierInvoiceDetail);
        }

        public async Task UpdateAsync(SupplierInvoiceDetail supplierInvoiceDetail)
        {
            ArgumentNullException.ThrowIfNull(supplierInvoiceDetail);
            await _supplierInvoiceDetailRepository.UpdateAsync(supplierInvoiceDetail);
        }
    }
}
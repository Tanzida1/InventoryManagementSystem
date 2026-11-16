
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface ISupplierInvoiceRepository
    {
        // 1. Get all supplier invoices
        Task<List<SupplierInvoice>> GetAllAsync();

        // 2. Get invoice by ID
        Task<SupplierInvoice?> GetByIdAsync(int supplierInvoiceId);

        // 3. Get invoices by supplier
        Task<List<SupplierInvoice>> GetBySupplierIdAsync(int supplierId);

        // 4. Add supplier invoice
        Task AddAsync(SupplierInvoice supplierInvoice);

        // 5. Update supplier invoice
        Task UpdateAsync(SupplierInvoice supplierInvoice);
    }
}

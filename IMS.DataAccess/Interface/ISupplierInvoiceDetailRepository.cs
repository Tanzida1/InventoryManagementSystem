
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface ISupplierInvoiceDetailRepository
    {
        // 1. Get all supplier invoice details
        Task<List<SupplierInvoiceDetail>> GetAllAsync();

        // 2. Get invoice detail by ID
        Task<SupplierInvoiceDetail?> GetByIdAsync(int supplierInvoiceDetailId);

        // 3. Get details by supplier invoice
        Task<List<SupplierInvoiceDetail>> GetBySupplierInvoiceIdAsync(int supplierInvoiceId);

        // 4. Get details by purchase order detail
        Task<List<SupplierInvoiceDetail>> GetByPurchaseOrderDetailIdAsync(int poDetailId);

        // 5. Add supplier invoice detail
        Task AddAsync(SupplierInvoiceDetail supplierInvoiceDetail);

        // 6. Update supplier invoice detail
        Task UpdateAsync(SupplierInvoiceDetail supplierInvoiceDetail);
    }
}

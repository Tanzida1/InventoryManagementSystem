using IMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public interface ISupplierInvoiceFacade
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

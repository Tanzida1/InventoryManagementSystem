
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IInvoiceReceiptMatchRepository
    {
        // 1. Get all invoice receipt matches
        Task<List<InvoiceReceiptMatch>> GetAllAsync();

        // 2. Get match by ID
        Task<InvoiceReceiptMatch?> GetByIdAsync(int id);

        // 3. Get matches by invoice detail
        Task<List<InvoiceReceiptMatch>> GetByInvoiceDetailIdAsync(int invoiceDetailId);

        // 4. Get matches by goods receipt detail
        Task<List<InvoiceReceiptMatch>> GetByGRNDetailIdAsync(int grnDetailId);

        // 5. Add invoice receipt match
        Task AddAsync(InvoiceReceiptMatch invoiceReceiptMatch);

        // 6. Update invoice receipt match
        Task UpdateAsync(InvoiceReceiptMatch invoiceReceiptMatch);
    }
}

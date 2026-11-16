
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IQuotationRepository
    {
        // 1. Get all quotations
        Task<List<Quotation>> GetAllAsync();

        // 2. Get quotation by ID
        Task<Quotation?> GetByIdAsync(int quotationId);

        // 3. Get quotations by supplier
        Task<List<Quotation>> GetBySupplierIdAsync(int supplierId);

        // 4. Add new quotation
        Task AddAsync(Quotation quotation);

        // 5. Update quotation
        Task UpdateAsync(Quotation quotation);
    }
}

using IMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public  interface IQuotationDetailFacade
    {
        // 1. Get all quotation details
        Task<List<QuotationDetail>> GetAllAsync();

        // 2. Get quotation detail by ID
        Task<QuotationDetail?> GetByIdAsync(int quotationDetailId);

        // 3. Get details by quotation
        Task<List<QuotationDetail>> GetByQuotationIdAsync(int quotationId);

        // 4. Get quotation details by item
        Task<List<QuotationDetail>> GetByItemIdAsync(int itemId);

        // 5. Add quotation detail
        Task AddAsync(QuotationDetail quotationDetail);

        // 6. Update quotation detail
        Task UpdateAsync(QuotationDetail quotationDetail);
    }
}

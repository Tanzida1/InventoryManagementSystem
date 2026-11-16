
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface ISaleDetailRepository
    {
        // 1. Get all sale details
        Task<List<SaleDetail>> GetAllAsync();

        // 2. Get sale detail by ID
        Task<SaleDetail?> GetByIdAsync(int saleDetailId);

        // 3. Get details by sale
        Task<List<SaleDetail>> GetBySaleIdAsync(int saleId);

        // 4. Get sales details by item
        Task<List<SaleDetail>> GetByItemIdAsync(int itemId);

        // 5. Add sale detail
        Task AddAsync(SaleDetail saleDetail);

        // 6. Update sale detail
        Task UpdateAsync(SaleDetail saleDetail);
    }
}


using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IStockRequisitionDetailRepository
    {
        // 1. Get all requisition details
        Task<List<StockRequisitionDetail>> GetAllAsync();

        // 2. Get detail by ID
        Task<StockRequisitionDetail?> GetByIdAsync(int requisitionDetailId);

        // 3. Get details of a requisition
        Task<List<StockRequisitionDetail>> GetByRequisitionIdAsync(int requisitionId);

        // 4. Get requisition details by item
        Task<List<StockRequisitionDetail>> GetByItemIdAsync(int itemId);

        // 5. Add requisition detail
        Task AddAsync(StockRequisitionDetail requisitionDetail);

        // 6. Update requisition detail
        Task UpdateAsync(StockRequisitionDetail requisitionDetail);
    }
}

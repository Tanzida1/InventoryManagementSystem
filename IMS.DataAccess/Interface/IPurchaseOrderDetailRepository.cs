
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IPurchaseOrderDetailRepository
    {
        // 1. Get all purchase order details
        Task<List<PurchaseOrderDetail>> GetAllAsync();

        // 2. Get detail by ID
        Task<PurchaseOrderDetail?> GetByIdAsync(int id);

        // 3. Get details by purchase order
        Task<List<PurchaseOrderDetail>> GetByPurchaseOrderIdAsync(int purchaseOrderId);

        // 4. Get details by item
        Task<List<PurchaseOrderDetail>> GetByItemIdAsync(int itemId);

        // 5. Add purchase order detail
        Task AddAsync(PurchaseOrderDetail purchaseOrderDetail);

        // 6. Update purchase order detail
        Task UpdateAsync(PurchaseOrderDetail purchaseOrderDetail);
    }
}

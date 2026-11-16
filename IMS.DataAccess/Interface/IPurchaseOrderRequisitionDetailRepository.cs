
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IPurchaseOrderRequisitionDetailRepository
    {
        // 1. Get all mapping records
        Task<List<PurchaseOrderRequisitionDetail>> GetAllAsync();

        // 2. Get mapping by ID
        Task<PurchaseOrderRequisitionDetail?> GetByIdAsync(int id);

        // 3. Get mappings by purchase order detail
        Task<List<PurchaseOrderRequisitionDetail>> GetByPODetailIdAsync(int poDetailId);

        // 4. Get mappings by purchase requisition detail
        Task<List<PurchaseOrderRequisitionDetail>> GetByPRDetailIdAsync(int prDetailId);

        // 5. Add mapping
        Task AddAsync(PurchaseOrderRequisitionDetail mapping);

        // 6. Remove mapping
        Task DeleteAsync(int id);
    }
}

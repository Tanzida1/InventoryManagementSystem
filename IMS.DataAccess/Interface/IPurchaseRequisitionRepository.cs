
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IPurchaseRequisitionRepository
    {
        // 1. Get all purchase requisitions
        Task<List<PurchaseRequisition>> GetAllAsync();

        // 2. Get requisition by ID
        Task<PurchaseRequisition?> GetByIdAsync(int id);

        // 3. Create purchase requisition
        Task AddAsync(PurchaseRequisition purchaseRequisition);

        // 4. Update requisition or its status
        Task UpdateAsync(PurchaseRequisition purchaseRequisition);
    }
}

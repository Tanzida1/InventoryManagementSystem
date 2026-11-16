using IMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public interface IPurchaseRequisitionDetailFacade
    {
        // 1. Get all purchase requisition details
        Task<List<PurchaseRequisitionDetail>> GetAllAsync();

        // 2. Get detail by ID
        Task<PurchaseRequisitionDetail?> GetByIdAsync(int purchaseRequisitionDetailId);

        // 3. Get details by purchase requisition
        Task<List<PurchaseRequisitionDetail>> GetByPurchaseRequisitionIdAsync(int purchaseRequisitionId);

        // 4. Get details by item
        Task<List<PurchaseRequisitionDetail>> GetByItemIdAsync(int itemId);

        // 5. Add purchase requisition detail
        Task AddAsync(PurchaseRequisitionDetail purchaseRequisitionDetail);

        // 6. Update purchase requisition detail
        Task UpdateAsync(PurchaseRequisitionDetail purchaseRequisitionDetail);
    }
}

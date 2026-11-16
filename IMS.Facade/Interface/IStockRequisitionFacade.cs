using IMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public interface IStockRequisitionFacade
    {
        // 1. Get all requisitions
        Task<List<StockRequisition>> GetAllAsync();

        // 2. Get requisition by ID
        Task<StockRequisition?> GetByIdAsync(int requisitionId);

        // 3. Get requisitions by requester
        Task<List<StockRequisition>> GetByRequesterIdAsync(int requesterId);

        // 4. Get requisitions by warehouse
        Task<List<StockRequisition>> GetByWarehouseIdAsync(int warehouseId);

        // 5. Create requisition
        Task AddAsync(StockRequisition requisition);

        // 6. Update requisition
        Task UpdateAsync(StockRequisition requisition);
    }
}

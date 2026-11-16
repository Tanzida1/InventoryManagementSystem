using IMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public interface ITransferOrderDetailFacade
    {
        // 1. Get all transfer details
        Task<List<TransferOrderDetail>> GetAllAsync();

        // 2. Get transfer detail by ID
        Task<TransferOrderDetail?> GetByIdAsync(int transferDetailId);

        // 3. Get details by transfer order
        Task<List<TransferOrderDetail>> GetByTransferOrderIdAsync(int transferOrderId);

        // 4. Get transfer details by item
        Task<List<TransferOrderDetail>> GetByItemIdAsync(int itemId);

        // 5. Add transfer detail
        Task AddAsync(TransferOrderDetail transferDetail);

        // 6. Update transfer detail
        Task UpdateAsync(TransferOrderDetail transferDetail);
    }
}

using IMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public interface ITransferOrderFacade
    {
        // 1. Get all transfer orders
        Task<List<TransferOrder>> GetAllAsync();

        // 2. Get transfer order by ID
        Task<TransferOrder?> GetByIdAsync(int transferOrderId);

        // 3. Get transfers by source warehouse
        Task<List<TransferOrder>> GetBySourceWarehouseIdAsync(int warehouseId);

        // 4. Get transfers by destination warehouse
        Task<List<TransferOrder>> GetByDestinationWarehouseIdAsync(int warehouseId);

        // 5. Get transfers by requester
        Task<List<TransferOrder>> GetByRequesterIdAsync(int requesterId);

        // 6. Create transfer order
        Task AddAsync(TransferOrder transferOrder);

        // 7. Update transfer order
        Task UpdateAsync(TransferOrder transferOrder);
    }
}

using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public interface IStockFacade
    {


        // 1. Get all stock records
        Task<List<Stock>> GetAllAsync();

        // 2. Get stock by ID
        Task<Stock?> GetByIdAsync(int stockId);

        // 3. Get stock by warehouse
        Task<List<Stock>> GetByWarehouseIdAsync(int warehouseId);

        // 4. Get stock by item
        Task<List<Stock>> GetByItemIdAsync(int itemId);

        // 5. Get stock by item and warehouse
        Task<Stock?> GetByItemAndWarehouseAsync(int itemId, int warehouseId);

        // 6. Add opening stock
        Task AddAsync(Stock stock);

        // 7. Update stock record
        Task UpdateAsync(Stock stock);
    }
}

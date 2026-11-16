using IMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public interface ISaleFacade
    {
        // 1. Get all sales
        Task<List<Sale>> GetAllAsync();

        // 2. Get sale by ID
        Task<Sale?> GetByIdAsync(int saleId);

        // 3. Get sales by warehouse
        Task<List<Sale>> GetByWarehouseIdAsync(int warehouseId);

        // 4. Get sales by user
        Task<List<Sale>> GetByUserIdAsync(int userId);

        // 5. Create new sale
        Task AddAsync(Sale sale);

        // 6. Update sale
        Task UpdateAsync(Sale sale);
    }
}

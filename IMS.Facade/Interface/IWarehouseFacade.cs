using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public  interface IWarehouseFacade
    {
        // 1. Get all warehouses
        Task<List<Warehouse>> GetAllAsync();

        // 2. Get warehouse by ID
        Task<Warehouse?> GetByIdAsync(int warehouseId);

        // 3. Add new warehouse
        Task AddAsync(Warehouse warehouse);

        // 4. Update warehouse
        Task UpdateAsync(Warehouse warehouse);

        // 5. Delete warehouse
        Task DeleteAsync(int warehouseId);
    }
}

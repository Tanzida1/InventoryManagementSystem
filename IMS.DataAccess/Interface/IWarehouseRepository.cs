
using IMS.Entities.Inventory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IWarehouseRepository
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

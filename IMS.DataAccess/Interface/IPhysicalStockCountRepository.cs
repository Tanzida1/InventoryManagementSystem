
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IPhysicalStockCountRepository
    {
        // 1. Get all physical stock counts
        Task<List<PhysicalStockCount>> GetAllAsync();

        // 2. Get count by ID
        Task<PhysicalStockCount?> GetByIdAsync(int id);

        // 3. Get counts by warehouse
        Task<List<PhysicalStockCount>> GetByWarehouseIdAsync(int warehouseId);

        // 4. Get counts by user
        Task<List<PhysicalStockCount>> GetByCountedByAsync(int userId);

        // 5. Create physical stock count
        Task AddAsync(PhysicalStockCount physicalStockCount);

        // 6. Update physical stock count
        Task UpdateAsync(PhysicalStockCount physicalStockCount);
    }
}

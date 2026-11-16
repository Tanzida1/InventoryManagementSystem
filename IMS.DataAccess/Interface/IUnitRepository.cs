
using IMS.Entities.Inventory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IUnitRepository
    {
        // 1. Get all units
        Task<List<Unit>> GetAllAsync();

        // 2. Get unit by ID
        Task<Unit?> GetByIdAsync(int unitId);

        // 3. Add new unit
        Task AddAsync(Unit unit);

        // 4. Update unit
        Task UpdateAsync(Unit unit);

        // 5. Delete unit
        Task DeleteAsync(int unitId);
    }
}

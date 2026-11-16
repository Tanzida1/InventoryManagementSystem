using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public interface IUnitFacade
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

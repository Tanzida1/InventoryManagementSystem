using IMS.Entities.Access;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public  interface IUserWarehouseFacade
    {
        // 1. Get all user warehouse assignments
        Task<List<UserWarehouse>> GetAllAsync();

        // 2. Get assignment by ID
        Task<UserWarehouse?> GetByIdAsync(int userWarehouseId);

        // 3. Get warehouses assigned to a user
        Task<List<UserWarehouse>> GetByUserIdAsync(int userId);

        // 4. Assign warehouse to a user
        Task AddAsync(UserWarehouse userWarehouse);

        // 5. Update user warehouse assignment
        Task UpdateAsync(UserWarehouse userWarehouse);

        // 6. Remove warehouse assignment
        Task DeleteAsync(int userWarehouseId);
    }
}

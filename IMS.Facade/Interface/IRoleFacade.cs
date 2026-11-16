using IMS.Entities.Access;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public interface IRoleFacade
    {

        // 1. Get all roles
        Task<List<Role>> GetAllAsync();

        // 2. Get role by ID
        Task<Role?> GetByIdAsync(int roleId);

        // 3. Add new role
        Task AddAsync(Role role);

        // 4. Update existing role
        Task UpdateAsync(Role role);

        // 5. Delete role
        Task DeleteAsync(int roleId);
    }
}

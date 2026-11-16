using IMS.Entities.Access;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public  interface IPermissionFacade
    {

        // 1. Get all permissions
        Task<List<Permission>> GetAllAsync();

        // 2. Get permission by ID
        Task<Permission?> GetByIdAsync(int permissionId);

        // 3. Add new permission
        Task AddAsync(Permission permission);

        // 4. Update existing permission
        Task UpdateAsync(Permission permission);

        // 5. Delete permission
        Task DeleteAsync(int permissionId);
    }
}

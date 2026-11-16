using System;
using System.Collections.Generic;
using System.Text;
using IMS.Entities.Access;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IPermissionRepository
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

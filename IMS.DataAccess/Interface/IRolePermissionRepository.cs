
using IMS.Entities.Access;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IRolePermissionRepository
    {
        // 1. Get all role permissions
        Task<List<RolePermission>> GetAllAsync();

        // 2. Get role permission by ID
        Task<RolePermission?> GetByIdAsync(int rolePermissionId);

        // 3. Assign permission to a role
        Task AddAsync(RolePermission rolePermission);

        // 4. Update role permission
        Task UpdateAsync(RolePermission rolePermission);

        // 5. Remove permission from a role
        Task DeleteAsync(int rolePermissionId);
    }
}

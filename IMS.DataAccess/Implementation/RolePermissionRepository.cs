
using IMS.DataAccess.Interface;
using IMS.Entities.Access;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Implementation
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RolePermissionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all role permissions
        public async Task<List<RolePermission>> GetAllAsync()
        {
            return await _dbContext.RolePermissions
                .OrderByDescending(rolePermission => rolePermission.RolePermissionId)
                .ToListAsync();
        }

        // 2. Get role permission by ID
        public async Task<RolePermission?> GetByIdAsync(int rolePermissionId)
        {
            return await _dbContext.RolePermissions.FindAsync(rolePermissionId);
        }

        // 3. Assign permission to a role
        public async Task AddAsync(RolePermission rolePermission)
        {
            await _dbContext.RolePermissions.AddAsync(rolePermission);
            await _dbContext.SaveChangesAsync();
        }

        // 4. Update role permission
        public async Task UpdateAsync(RolePermission rolePermission)
        {
            _dbContext.RolePermissions.Update(rolePermission);
            await _dbContext.SaveChangesAsync();
        }

        // 5. Remove permission from a role
        public async Task DeleteAsync(int rolePermissionId)
        {
            var rolePermission = await _dbContext.RolePermissions
                .FindAsync(rolePermissionId);

            if (rolePermission == null)
                return;

            _dbContext.RolePermissions.Remove(rolePermission);
            await _dbContext.SaveChangesAsync();
        }
    }
}

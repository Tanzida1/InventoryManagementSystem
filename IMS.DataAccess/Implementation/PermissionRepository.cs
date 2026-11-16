
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
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PermissionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all permissions
        public async Task<List<Permission>> GetAllAsync()
        {
            return await _dbContext.Permissions
                .OrderByDescending(permission => permission.PermissionId)
                .ToListAsync();
        }

        // 2. Get permission by ID
        public async Task<Permission?> GetByIdAsync(int id)
        {
            return await _dbContext.Permissions.FindAsync(id);
        }

        // 3. Add permission
        public async Task AddAsync(Permission permission)
        {
            await _dbContext.Permissions.AddAsync(permission);
            await _dbContext.SaveChangesAsync();
        }

        // 4. Update permission
        public async Task UpdateAsync(Permission permission)
        {
            _dbContext.Permissions.Update(permission);
            await _dbContext.SaveChangesAsync();
        }

        // 5. Delete permission
        public async Task DeleteAsync(int id)
        {
            var permission = await _dbContext.Permissions.FindAsync(id);

            if (permission == null)
                return;

            _dbContext.Permissions.Remove(permission);
            await _dbContext.SaveChangesAsync();
        }
    }
}

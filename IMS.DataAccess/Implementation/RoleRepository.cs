
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
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RoleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all roles
        public async Task<List<Role>> GetAllAsync()
        {
            return await _dbContext.Roles
                .OrderByDescending(role => role.RoleId)
                .ToListAsync();
        }

        // 2. Get role by ID
        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _dbContext.Roles.FindAsync(id);
        }

        // 3. Add role
        public async Task AddAsync(Role role)
        {
            await _dbContext.Roles.AddAsync(role);
            await _dbContext.SaveChangesAsync();
        }

        // 4. Update role
        public async Task UpdateAsync(Role role)
        {
            _dbContext.Roles.Update(role);
            await _dbContext.SaveChangesAsync();
        }

        // 5. Delete role
        public async Task DeleteAsync(int id)
        {
            var role = await _dbContext.Roles.FindAsync(id);

            if (role == null)
                return;

            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();
        }
    }
}

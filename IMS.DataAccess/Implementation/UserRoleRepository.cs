
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
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRoleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all user roles
        public async Task<List<UserRole>> GetAllAsync()
        {
            return await _dbContext.UserRoles
                .OrderByDescending(userRole => userRole.UserRoleId)
                .ToListAsync();
        }

        // 2. Get user role by ID
        public async Task<UserRole?> GetByIdAsync(int userRoleId)
        {
            return await _dbContext.UserRoles.FindAsync(userRoleId);
        }

        // 3. Get roles assigned to a user
        public async Task<List<UserRole>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.UserRoles
                .Where(userRole => userRole.UserId == userId)
                .ToListAsync();
        }

        // 4. Get users assigned to a role
        public async Task<List<UserRole>> GetByRoleIdAsync(int roleId)
        {
            return await _dbContext.UserRoles
                .Where(userRole => userRole.RoleId == roleId)
                .ToListAsync();
        }

        // 5. Assign role to user
        public async Task AddAsync(UserRole userRole)
        {
            await _dbContext.UserRoles.AddAsync(userRole);
            await _dbContext.SaveChangesAsync();
        }

        // 6. Update user role
        public async Task UpdateAsync(UserRole userRole)
        {
            _dbContext.UserRoles.Update(userRole);
            await _dbContext.SaveChangesAsync();
        }

        // 7. Remove role from user
        public async Task DeleteAsync(int userRoleId)
        {
            var userRole = await _dbContext.UserRoles.FindAsync(userRoleId);

            if (userRole == null)
                return;

            _dbContext.UserRoles.Remove(userRole);
            await _dbContext.SaveChangesAsync();
        }
    }
}

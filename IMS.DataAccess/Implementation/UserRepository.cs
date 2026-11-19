
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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all users

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users
                .Include(user => user.UserRoles)
                    .ThenInclude(userRole => userRole.Role)
                .OrderByDescending(user => user.UserId)
                .ToListAsync();
        }


        // 2. Get user by ID

        public async Task<User?> GetByIdAsync(int userId)
        {
            return await _dbContext.Users
                .Include(user => user.UserRoles)
                    .ThenInclude(userRole => userRole.Role)
                .FirstOrDefaultAsync(user => user.UserId == userId);
        }

        // 3. Get user by Email


        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.Users
                .Include(user => user.UserRoles)
                    .ThenInclude(userRole => userRole.Role)
                .Where(user => user.Email == email)
                .FirstOrDefaultAsync();
        }

        

        // 4. Add user
        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        // 5. Update user
        public async Task UpdateAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        // 6. Delete user
        public async Task DeleteAsync(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);

            if (user == null)
                return;

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }


        // 7. Register user with role
        public async Task RegisterAsync(User user, string roleName)
        {
            // Find the selected role
            var role = await _dbContext.Roles
                .FirstOrDefaultAsync(existingRole =>
                    existingRole.RoleName == roleName);

            if (role == null)
            {
                throw new InvalidOperationException(
                    "Selected role does not exist.");
            }

            // Assign role to the new user
            user.UserRoles.Add(new UserRole
            {
                RoleId = role.RoleId
            });

            // Add user and assigned role together
            await _dbContext.Users.AddAsync(user);

            // Save both records
            await _dbContext.SaveChangesAsync();
        }



        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _dbContext.Roles
                .OrderBy(role => role.RoleName)
                .ToListAsync();
        }



        public async Task<bool> UpdateUserRoleAsync(int userId, string roleName)
        {
            var user = await _dbContext.Users
                .Include(existingUser => existingUser.UserRoles)
                .FirstOrDefaultAsync(existingUser => existingUser.UserId == userId);

            if (user == null)
                return false;

            var role = await _dbContext.Roles
                .FirstOrDefaultAsync(existingRole => existingRole.RoleName == roleName);

            if (role == null)
                return false;

            // Delete the previous UserRole records
            _dbContext.RemoveRange(user.UserRoles);

            // Add the new UserRole record
            var newUserRole = new UserRole
            {
                UserId = userId,
                RoleId = role.RoleId
            };

            _dbContext.Add(newUserRole);

            await _dbContext.SaveChangesAsync();

            return true;
        }





        public async Task<bool> SetActiveStatusAsync(
            int userId,
            bool isActive)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(existingUser =>
                    existingUser.UserId == userId);

            if (user == null)
                return false;

            user.IsActive = isActive;

            await _dbContext.SaveChangesAsync();

            return true;
        }











    }
}


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
                .OrderByDescending(user => user.UserId)
                .ToListAsync();
        }

        // 2. Get user by ID
        public async Task<User?> GetByIdAsync(int userId)
        {
            return await _dbContext.Users.FindAsync(userId);
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






    }
}

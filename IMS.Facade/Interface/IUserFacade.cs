using IMS.Entities.Access;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public interface IUserFacade
    {
        // 1. Get all users
        Task<List<User>> GetAllAsync();

        // 2. Get user by ID
        Task<User?> GetByIdAsync(int userId);

        // 3. Get user by email
        Task<User?> GetByEmailAsync(string email);

        // 4. Add new user
        Task AddAsync(User user);

        // 5. Update existing user
        Task UpdateAsync(User user);

        // 6. Delete user
        Task DeleteAsync(int userId);
        // 7. Register new user
        Task<bool> RegisterAsync(User user, string password, string roleName);
        // 8. Authenticate user during login
        Task<User?> AuthenticateAsync(string email, string password);


        // 8. Get all available roles
        Task<List<Role>> GetAllRolesAsync();

        // 9. Update user's assigned role
        Task<bool> UpdateUserRoleAsync(int userId, string roleName);

        // 10. Activate or deactivate user
        Task<bool> SetActiveStatusAsync(int userId, bool isActive);




    }
}


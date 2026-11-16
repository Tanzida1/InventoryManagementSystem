
using IMS.Entities.Access;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IUserRepository
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

        // 7. Register user with role
        Task RegisterAsync(User user, string roleName);


    }
}

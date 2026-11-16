using IMS.Entities.Access;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public interface IUserRoleFacade
    {
        // 1. Get all user roles
        Task<List<UserRole>> GetAllAsync();

        // 2. Get user role by ID
        Task<UserRole?> GetByIdAsync(int userRoleId);

        // 3. Assign role to a user
        Task AddAsync(UserRole userRole);

        // 4. Update user role
        Task UpdateAsync(UserRole userRole);

        // 5. Remove role from a user
        Task DeleteAsync(int userRoleId);
    }
}

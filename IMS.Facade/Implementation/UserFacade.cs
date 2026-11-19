using IMS.DataAccess.Interface;
using IMS.Entities.Access;
using IMS.Facade.Interface;
using Microsoft.AspNetCore.Identity;
namespace IMS.Facade.Implementation
{
    public class UserFacade : IUserFacade
    {
        private readonly IUserRepository _userRepository;

        public UserFacade(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task AddAsync(User user)
        {
            ArgumentNullException.ThrowIfNull(user);
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            ArgumentNullException.ThrowIfNull(user);
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int userId)
        {
            await _userRepository.DeleteAsync(userId);
        }

        // 7. Register new user
        public async Task<bool> RegisterAsync(
            User user,
            string password,
            string roleName)
        {
            ArgumentNullException.ThrowIfNull(user);

            // Check whether email already exists
            var existingUser = await _userRepository
                .GetByEmailAsync(user.Email);

            if (existingUser != null)
            {
                return false;
            }

            // Hash the password before saving
            var passwordHasher = new PasswordHasher<User>();

            user.PasswordHash = passwordHasher.HashPassword(
                user,
                password);

            // Keep new user active
            user.IsActive = true;

            // Save user with assigned role
            await _userRepository.RegisterAsync(user, roleName);

            return true;
        }





        // 8. Authenticate user during login
        public async Task<User?> AuthenticateAsync(
            string email,
            string password)
        {
            // Find user by email
            var user = await _userRepository.GetByEmailAsync(email);

            // Check whether user exists
            if (user == null)
            {
                return null;
            }

            // Check whether user is active
            if (!user.IsActive)
            {
                return null;
            }

            // Verify password
            var passwordHasher = new PasswordHasher<User>();

            var result = passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                password);

            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return user;
        }


        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _userRepository.GetAllRolesAsync();
        }



        public async Task<bool> UpdateUserRoleAsync(
            int userId,
            string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return false;

            // Find the user
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
                return false;

            // Check whether the user is currently an Administrator
            bool isAdministrator = user.UserRoles.Any(userRole =>
                userRole.Role?.RoleName == "Administrator");

            // Check whether another active Administrator exists
            if (isAdministrator && roleName != "Administrator")
            {
                var allUsers = await _userRepository.GetAllAsync();

                int activeAdministrators = allUsers.Count(existingUser =>
                    existingUser.IsActive &&
                    existingUser.UserRoles.Any(userRole =>
                        userRole.Role?.RoleName == "Administrator"));

                if (activeAdministrators <= 1)
                    return false;
            }

            return await _userRepository.UpdateUserRoleAsync(
                userId,
                roleName);
        }







        public async Task<bool> SetActiveStatusAsync(
            int userId,
            bool isActive)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
                return false;

            // Prevent deactivating the last active Administrator
            if (!isActive)
            {
                bool isAdministrator = user.UserRoles.Any(userRole =>
                    userRole.Role?.RoleName == "Administrator");

                if (isAdministrator)
                {
                    var allUsers = await _userRepository.GetAllAsync();

                    int activeAdministrators = allUsers.Count(existingUser =>
                        existingUser.IsActive &&
                        existingUser.UserRoles.Any(userRole =>
                            userRole.Role?.RoleName == "Administrator"));

                    if (activeAdministrators <= 1)
                        return false;
                }
            }

            return await _userRepository.SetActiveStatusAsync(
                userId,
                isActive);
        }









    }
}
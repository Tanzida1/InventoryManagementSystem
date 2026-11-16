using IMS.DataAccess.Interface;
using IMS.Entities.Access;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class UserRoleFacade : IUserRoleFacade
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleFacade(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<List<UserRole>> GetAllAsync()
        {
            return await _userRoleRepository.GetAllAsync();
        }

        public async Task<UserRole?> GetByIdAsync(int userRoleId)
        {
            return await _userRoleRepository.GetByIdAsync(userRoleId);
        }

        public async Task AddAsync(UserRole userRole)
        {
            ArgumentNullException.ThrowIfNull(userRole);
            await _userRoleRepository.AddAsync(userRole);
        }

        public async Task UpdateAsync(UserRole userRole)
        {
            ArgumentNullException.ThrowIfNull(userRole);
            await _userRoleRepository.UpdateAsync(userRole);
        }

        public async Task DeleteAsync(int userRoleId)
        {
            await _userRoleRepository.DeleteAsync(userRoleId);
        }
    }
}
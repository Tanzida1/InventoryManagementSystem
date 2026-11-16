using IMS.DataAccess.Interface;
using IMS.Entities.Access;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class RoleFacade : IRoleFacade
    {
        private readonly IRoleRepository _roleRepository;

        public RoleFacade(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        public async Task<Role?> GetByIdAsync(int roleId)
        {
            return await _roleRepository.GetByIdAsync(roleId);
        }

        public async Task AddAsync(Role role)
        {
            ArgumentNullException.ThrowIfNull(role);
            await _roleRepository.AddAsync(role);
        }

        public async Task UpdateAsync(Role role)
        {
            ArgumentNullException.ThrowIfNull(role);
            await _roleRepository.UpdateAsync(role);
        }

        public async Task DeleteAsync(int roleId)
        {
            await _roleRepository.DeleteAsync(roleId);
        }
    }
}
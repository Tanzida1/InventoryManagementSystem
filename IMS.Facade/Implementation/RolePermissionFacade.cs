using IMS.DataAccess.Interface;
using IMS.Entities.Access;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class RolePermissionFacade : IRolePermissionFacade
    {
        private readonly IRolePermissionRepository _rolePermissionRepository;

        public RolePermissionFacade(IRolePermissionRepository rolePermissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
        }

        public async Task<List<RolePermission>> GetAllAsync()
        {
            return await _rolePermissionRepository.GetAllAsync();
        }

        public async Task<RolePermission?> GetByIdAsync(int rolePermissionId)
        {
            return await _rolePermissionRepository.GetByIdAsync(rolePermissionId);
        }

        public async Task AddAsync(RolePermission rolePermission)
        {
            ArgumentNullException.ThrowIfNull(rolePermission);
            await _rolePermissionRepository.AddAsync(rolePermission);
        }

        public async Task UpdateAsync(RolePermission rolePermission)
        {
            ArgumentNullException.ThrowIfNull(rolePermission);
            await _rolePermissionRepository.UpdateAsync(rolePermission);
        }

        public async Task DeleteAsync(int rolePermissionId)
        {
            await _rolePermissionRepository.DeleteAsync(rolePermissionId);
        }
    }
}
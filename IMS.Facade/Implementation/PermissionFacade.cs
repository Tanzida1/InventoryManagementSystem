using IMS.DataAccess.Interface;
using IMS.Entities.Access;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class PermissionFacade : IPermissionFacade
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionFacade(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<List<Permission>> GetAllAsync()
        {
            return await _permissionRepository.GetAllAsync();
        }

        public async Task<Permission?> GetByIdAsync(int permissionId)
        {
            return await _permissionRepository.GetByIdAsync(permissionId);
        }

        public async Task AddAsync(Permission permission)
        {
            ArgumentNullException.ThrowIfNull(permission);
            await _permissionRepository.AddAsync(permission);
        }

        public async Task UpdateAsync(Permission permission)
        {
            ArgumentNullException.ThrowIfNull(permission);
            await _permissionRepository.UpdateAsync(permission);
        }

        public async Task DeleteAsync(int permissionId)
        {
            await _permissionRepository.DeleteAsync(permissionId);
        }
    }
}
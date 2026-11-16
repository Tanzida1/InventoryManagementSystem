using IMS.DataAccess.Interface;
using IMS.Entities.Access;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class UserWarehouseFacade : IUserWarehouseFacade
    {
        private readonly IUserWarehouseRepository _userWarehouseRepository;

        public UserWarehouseFacade(IUserWarehouseRepository userWarehouseRepository)
        {
            _userWarehouseRepository = userWarehouseRepository;
        }

        public async Task<List<UserWarehouse>> GetAllAsync()
        {
            return await _userWarehouseRepository.GetAllAsync();
        }

        public async Task<UserWarehouse?> GetByIdAsync(int userWarehouseId)
        {
            return await _userWarehouseRepository.GetByIdAsync(userWarehouseId);
        }

        public async Task<List<UserWarehouse>> GetByUserIdAsync(int userId)
        {
            return await _userWarehouseRepository.GetByUserIdAsync(userId);
        }

        public async Task AddAsync(UserWarehouse userWarehouse)
        {
            ArgumentNullException.ThrowIfNull(userWarehouse);
            await _userWarehouseRepository.AddAsync(userWarehouse);
        }

        public async Task UpdateAsync(UserWarehouse userWarehouse)
        {
            ArgumentNullException.ThrowIfNull(userWarehouse);
            await _userWarehouseRepository.UpdateAsync(userWarehouse);
        }

        public async Task DeleteAsync(int userWarehouseId)
        {
            await _userWarehouseRepository.DeleteAsync(userWarehouseId);
        }
    }
}
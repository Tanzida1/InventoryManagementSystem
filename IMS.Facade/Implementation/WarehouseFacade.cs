using IMS.DataAccess.Interface;
using IMS.Entities.Inventory;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class WarehouseFacade : IWarehouseFacade
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseFacade(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<List<Warehouse>> GetAllAsync()
        {
            return await _warehouseRepository.GetAllAsync();
        }

        public async Task<Warehouse?> GetByIdAsync(int warehouseId)
        {
            return await _warehouseRepository.GetByIdAsync(warehouseId);
        }

        public async Task AddAsync(Warehouse warehouse)
        {
            ArgumentNullException.ThrowIfNull(warehouse);
            await _warehouseRepository.AddAsync(warehouse);
        }

        public async Task UpdateAsync(Warehouse warehouse)
        {
            ArgumentNullException.ThrowIfNull(warehouse);
            await _warehouseRepository.UpdateAsync(warehouse);
        }

        public async Task DeleteAsync(int warehouseId)
        {
            await _warehouseRepository.DeleteAsync(warehouseId);
        }
    }
}
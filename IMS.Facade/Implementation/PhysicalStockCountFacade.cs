using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class PhysicalStockCountFacade : IPhysicalStockCountFacade
    {
        private readonly IPhysicalStockCountRepository _physicalStockCountRepository;

        public PhysicalStockCountFacade(IPhysicalStockCountRepository physicalStockCountRepository)
        {
            _physicalStockCountRepository = physicalStockCountRepository;
        }

        public async Task<List<PhysicalStockCount>> GetAllAsync()
        {
            return await _physicalStockCountRepository.GetAllAsync();
        }

        public async Task<PhysicalStockCount?> GetByIdAsync(int id)
        {
            return await _physicalStockCountRepository.GetByIdAsync(id);
        }

        public async Task<List<PhysicalStockCount>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _physicalStockCountRepository.GetByWarehouseIdAsync(warehouseId);
        }

        public async Task<List<PhysicalStockCount>> GetByCountedByAsync(int userId)
        {
            return await _physicalStockCountRepository.GetByCountedByAsync(userId);
        }

        public async Task AddAsync(PhysicalStockCount physicalStockCount)
        {
            ArgumentNullException.ThrowIfNull(physicalStockCount);
            await _physicalStockCountRepository.AddAsync(physicalStockCount);
        }

        public async Task UpdateAsync(PhysicalStockCount physicalStockCount)
        {
            ArgumentNullException.ThrowIfNull(physicalStockCount);
            await _physicalStockCountRepository.UpdateAsync(physicalStockCount);
        }
    }
}
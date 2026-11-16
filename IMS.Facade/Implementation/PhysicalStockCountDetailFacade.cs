using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class PhysicalStockCountDetailFacade : IPhysicalStockCountDetailFacade
    {
        private readonly IPhysicalStockCountDetailRepository _physicalStockCountDetailRepository;

        public PhysicalStockCountDetailFacade(
            IPhysicalStockCountDetailRepository physicalStockCountDetailRepository)
        {
            _physicalStockCountDetailRepository = physicalStockCountDetailRepository;
        }

        public async Task<List<PhysicalStockCountDetail>> GetAllAsync()
        {
            return await _physicalStockCountDetailRepository.GetAllAsync();
        }

        public async Task<PhysicalStockCountDetail?> GetByIdAsync(int id)
        {
            return await _physicalStockCountDetailRepository.GetByIdAsync(id);
        }

        public async Task<List<PhysicalStockCountDetail>> GetByCountIdAsync(int countId)
        {
            return await _physicalStockCountDetailRepository.GetByCountIdAsync(countId);
        }

        public async Task<List<PhysicalStockCountDetail>> GetByItemIdAsync(int itemId)
        {
            return await _physicalStockCountDetailRepository.GetByItemIdAsync(itemId);
        }

        public async Task AddAsync(PhysicalStockCountDetail physicalStockCountDetail)
        {
            ArgumentNullException.ThrowIfNull(physicalStockCountDetail);
            await _physicalStockCountDetailRepository.AddAsync(physicalStockCountDetail);
        }

        public async Task UpdateAsync(PhysicalStockCountDetail physicalStockCountDetail)
        {
            ArgumentNullException.ThrowIfNull(physicalStockCountDetail);
            await _physicalStockCountDetailRepository.UpdateAsync(physicalStockCountDetail);
        }
    }
}
using IMS.DataAccess.Interface;
using IMS.Entities.Inventory;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class UnitFacade : IUnitFacade
    {
        private readonly IUnitRepository _unitRepository;

        public UnitFacade(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<List<Unit>> GetAllAsync()
        {
            return await _unitRepository.GetAllAsync();
        }

        public async Task<Unit?> GetByIdAsync(int unitId)
        {
            return await _unitRepository.GetByIdAsync(unitId);
        }

        public async Task AddAsync(Unit unit)
        {
            ArgumentNullException.ThrowIfNull(unit);
            await _unitRepository.AddAsync(unit);
        }

        public async Task UpdateAsync(Unit unit)
        {
            ArgumentNullException.ThrowIfNull(unit);
            await _unitRepository.UpdateAsync(unit);
        }

        public async Task DeleteAsync(int unitId)
        {
            await _unitRepository.DeleteAsync(unitId);
        }
    }
}
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class SaleFacade : ISaleFacade
    {
        private readonly ISaleRepository _saleRepository;

        public SaleFacade(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<List<Sale>> GetAllAsync()
        {
            return await _saleRepository.GetAllAsync();
        }

        public async Task<Sale?> GetByIdAsync(int saleId)
        {
            return await _saleRepository.GetByIdAsync(saleId);
        }

        public async Task<List<Sale>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _saleRepository.GetByWarehouseIdAsync(warehouseId);
        }

        public async Task<List<Sale>> GetByUserIdAsync(int userId)
        {
            return await _saleRepository.GetByUserIdAsync(userId);
        }

        public async Task AddAsync(Sale sale)
        {
            ArgumentNullException.ThrowIfNull(sale);
            await _saleRepository.AddAsync(sale);
        }

        public async Task UpdateAsync(Sale sale)
        {
            ArgumentNullException.ThrowIfNull(sale);
            await _saleRepository.UpdateAsync(sale);
        }
    }
}
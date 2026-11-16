using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class SaleDetailFacade : ISaleDetailFacade
    {
        private readonly ISaleDetailRepository _saleDetailRepository;

        public SaleDetailFacade(ISaleDetailRepository saleDetailRepository)
        {
            _saleDetailRepository = saleDetailRepository;
        }

        public async Task<List<SaleDetail>> GetAllAsync()
        {
            return await _saleDetailRepository.GetAllAsync();
        }

        public async Task<SaleDetail?> GetByIdAsync(int saleDetailId)
        {
            return await _saleDetailRepository.GetByIdAsync(saleDetailId);
        }

        public async Task<List<SaleDetail>> GetBySaleIdAsync(int saleId)
        {
            return await _saleDetailRepository.GetBySaleIdAsync(saleId);
        }

        public async Task<List<SaleDetail>> GetByItemIdAsync(int itemId)
        {
            return await _saleDetailRepository.GetByItemIdAsync(itemId);
        }

        public async Task AddAsync(SaleDetail saleDetail)
        {
            ArgumentNullException.ThrowIfNull(saleDetail);
            await _saleDetailRepository.AddAsync(saleDetail);
        }

        public async Task UpdateAsync(SaleDetail saleDetail)
        {
            ArgumentNullException.ThrowIfNull(saleDetail);
            await _saleDetailRepository.UpdateAsync(saleDetail);
        }
    }
}
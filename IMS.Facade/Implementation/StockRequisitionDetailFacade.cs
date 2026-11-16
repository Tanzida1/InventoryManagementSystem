using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class StockRequisitionDetailFacade : IStockRequisitionDetailFacade
    {
        private readonly IStockRequisitionDetailRepository _stockRequisitionDetailRepository;

        public StockRequisitionDetailFacade(IStockRequisitionDetailRepository stockRequisitionDetailRepository)
        {
            _stockRequisitionDetailRepository = stockRequisitionDetailRepository;
        }

        public async Task<List<StockRequisitionDetail>> GetAllAsync()
        {
            return await _stockRequisitionDetailRepository.GetAllAsync();
        }

        public async Task<StockRequisitionDetail?> GetByIdAsync(int requisitionDetailId)
        {
            return await _stockRequisitionDetailRepository.GetByIdAsync(requisitionDetailId);
        }

        public async Task<List<StockRequisitionDetail>> GetByRequisitionIdAsync(int requisitionId)
        {
            return await _stockRequisitionDetailRepository.GetByRequisitionIdAsync(requisitionId);
        }

        public async Task<List<StockRequisitionDetail>> GetByItemIdAsync(int itemId)
        {
            return await _stockRequisitionDetailRepository.GetByItemIdAsync(itemId);
        }

        public async Task AddAsync(StockRequisitionDetail requisitionDetail)
        {
            ArgumentNullException.ThrowIfNull(requisitionDetail);
            await _stockRequisitionDetailRepository.AddAsync(requisitionDetail);
        }

        public async Task UpdateAsync(StockRequisitionDetail requisitionDetail)
        {
            ArgumentNullException.ThrowIfNull(requisitionDetail);
            await _stockRequisitionDetailRepository.UpdateAsync(requisitionDetail);
        }
    }
}
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class StockAdjustmentDetailFacade : IStockAdjustmentDetailFacade
    {
        private readonly IStockAdjustmentDetailRepository _stockAdjustmentDetailRepository;

        public StockAdjustmentDetailFacade(IStockAdjustmentDetailRepository stockAdjustmentDetailRepository)
        {
            _stockAdjustmentDetailRepository = stockAdjustmentDetailRepository;
        }

        public async Task<List<StockAdjustmentDetail>> GetAllAsync()
        {
            return await _stockAdjustmentDetailRepository.GetAllAsync();
        }

        public async Task<StockAdjustmentDetail?> GetByIdAsync(int adjustmentDetailId)
        {
            return await _stockAdjustmentDetailRepository.GetByIdAsync(adjustmentDetailId);
        }

        public async Task<List<StockAdjustmentDetail>> GetByAdjustmentIdAsync(int adjustmentId)
        {
            return await _stockAdjustmentDetailRepository.GetByAdjustmentIdAsync(adjustmentId);
        }

        public async Task<List<StockAdjustmentDetail>> GetByItemIdAsync(int itemId)
        {
            return await _stockAdjustmentDetailRepository.GetByItemIdAsync(itemId);
        }

        public async Task AddAsync(StockAdjustmentDetail adjustmentDetail)
        {
            ArgumentNullException.ThrowIfNull(adjustmentDetail);
            await _stockAdjustmentDetailRepository.AddAsync(adjustmentDetail);
        }

        public async Task UpdateAsync(StockAdjustmentDetail adjustmentDetail)
        {
            ArgumentNullException.ThrowIfNull(adjustmentDetail);
            await _stockAdjustmentDetailRepository.UpdateAsync(adjustmentDetail);
        }
    }
}
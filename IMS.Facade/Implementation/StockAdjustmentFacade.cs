using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class StockAdjustmentFacade : IStockAdjustmentFacade
    {
        private readonly IStockAdjustmentRepository _stockAdjustmentRepository;

        public StockAdjustmentFacade(IStockAdjustmentRepository stockAdjustmentRepository)
        {
            _stockAdjustmentRepository = stockAdjustmentRepository;
        }

        public async Task<List<StockAdjustment>> GetAllAsync()
        {
            return await _stockAdjustmentRepository.GetAllAsync();
        }

        public async Task<StockAdjustment?> GetByIdAsync(int adjustmentId)
        {
            return await _stockAdjustmentRepository.GetByIdAsync(adjustmentId);
        }

        public async Task<List<StockAdjustment>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _stockAdjustmentRepository.GetByWarehouseIdAsync(warehouseId);
        }

        public async Task<List<StockAdjustment>> GetByRequesterIdAsync(int requesterId)
        {
            return await _stockAdjustmentRepository.GetByRequesterIdAsync(requesterId);
        }

        public async Task AddAsync(StockAdjustment stockAdjustment)
        {
            ArgumentNullException.ThrowIfNull(stockAdjustment);
            await _stockAdjustmentRepository.AddAsync(stockAdjustment);
        }

        public async Task UpdateAsync(StockAdjustment stockAdjustment)
        {
            ArgumentNullException.ThrowIfNull(stockAdjustment);
            await _stockAdjustmentRepository.UpdateAsync(stockAdjustment);
        }
    }
}
using IMS.DataAccess.Interface;
using IMS.Entities.Inventory;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class StockFacade : IStockFacade
    {
        private readonly IStockRepository _stockRepository;

        public StockFacade(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _stockRepository.GetAllAsync();
        }

        public async Task<Stock?> GetByIdAsync(int stockId)
        {
            return await _stockRepository.GetByIdAsync(stockId);
        }

        public async Task<List<Stock>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _stockRepository.GetByWarehouseIdAsync(warehouseId);
        }

        public async Task<List<Stock>> GetByItemIdAsync(int itemId)
        {
            return await _stockRepository.GetByItemIdAsync(itemId);
        }

        public async Task<Stock?> GetByItemAndWarehouseAsync(int itemId, int warehouseId)
        {
            return await _stockRepository.GetByItemAndWarehouseAsync(itemId, warehouseId);
        }

        public async Task AddAsync(Stock stock)
        {
            ArgumentNullException.ThrowIfNull(stock);
            await _stockRepository.AddAsync(stock);
        }

        public async Task UpdateAsync(Stock stock)
        {
            ArgumentNullException.ThrowIfNull(stock);
            await _stockRepository.UpdateAsync(stock);
        }
    }
}
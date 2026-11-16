using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class StockRequisitionFacade : IStockRequisitionFacade
    {
        private readonly IStockRequisitionRepository _stockRequisitionRepository;

        public StockRequisitionFacade(IStockRequisitionRepository stockRequisitionRepository)
        {
            _stockRequisitionRepository = stockRequisitionRepository;
        }

        public async Task<List<StockRequisition>> GetAllAsync()
        {
            return await _stockRequisitionRepository.GetAllAsync();
        }

        public async Task<StockRequisition?> GetByIdAsync(int requisitionId)
        {
            return await _stockRequisitionRepository.GetByIdAsync(requisitionId);
        }

        public async Task<List<StockRequisition>> GetByRequesterIdAsync(int requesterId)
        {
            return await _stockRequisitionRepository.GetByRequesterIdAsync(requesterId);
        }

        public async Task<List<StockRequisition>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _stockRequisitionRepository.GetByWarehouseIdAsync(warehouseId);
        }

        public async Task AddAsync(StockRequisition requisition)
        {
            ArgumentNullException.ThrowIfNull(requisition);
            await _stockRequisitionRepository.AddAsync(requisition);
        }

        public async Task UpdateAsync(StockRequisition requisition)
        {
            ArgumentNullException.ThrowIfNull(requisition);
            await _stockRequisitionRepository.UpdateAsync(requisition);
        }
    }
}
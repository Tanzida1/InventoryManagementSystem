using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class TransferOrderFacade : ITransferOrderFacade
    {
        private readonly ITransferOrderRepository _transferOrderRepository;

        public TransferOrderFacade(ITransferOrderRepository transferOrderRepository)
        {
            _transferOrderRepository = transferOrderRepository;
        }

        public async Task<List<TransferOrder>> GetAllAsync()
        {
            return await _transferOrderRepository.GetAllAsync();
        }

        public async Task<TransferOrder?> GetByIdAsync(int transferOrderId)
        {
            return await _transferOrderRepository.GetByIdAsync(transferOrderId);
        }

        public async Task<List<TransferOrder>> GetBySourceWarehouseIdAsync(int warehouseId)
        {
            return await _transferOrderRepository.GetBySourceWarehouseIdAsync(warehouseId);
        }

        public async Task<List<TransferOrder>> GetByDestinationWarehouseIdAsync(int warehouseId)
        {
            return await _transferOrderRepository.GetByDestinationWarehouseIdAsync(warehouseId);
        }

        public async Task<List<TransferOrder>> GetByRequesterIdAsync(int requesterId)
        {
            return await _transferOrderRepository.GetByRequesterIdAsync(requesterId);
        }

        public async Task AddAsync(TransferOrder transferOrder)
        {
            ArgumentNullException.ThrowIfNull(transferOrder);
            await _transferOrderRepository.AddAsync(transferOrder);
        }

        public async Task UpdateAsync(TransferOrder transferOrder)
        {
            ArgumentNullException.ThrowIfNull(transferOrder);
            await _transferOrderRepository.UpdateAsync(transferOrder);
        }
    }
}
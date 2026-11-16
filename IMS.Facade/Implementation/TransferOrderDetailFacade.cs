using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class TransferOrderDetailFacade : ITransferOrderDetailFacade
    {
        private readonly ITransferOrderDetailRepository _transferOrderDetailRepository;

        public TransferOrderDetailFacade(ITransferOrderDetailRepository transferOrderDetailRepository)
        {
            _transferOrderDetailRepository = transferOrderDetailRepository;
        }

        public async Task<List<TransferOrderDetail>> GetAllAsync()
        {
            return await _transferOrderDetailRepository.GetAllAsync();
        }

        public async Task<TransferOrderDetail?> GetByIdAsync(int transferDetailId)
        {
            return await _transferOrderDetailRepository.GetByIdAsync(transferDetailId);
        }

        public async Task<List<TransferOrderDetail>> GetByTransferOrderIdAsync(int transferOrderId)
        {
            return await _transferOrderDetailRepository.GetByTransferOrderIdAsync(transferOrderId);
        }

        public async Task<List<TransferOrderDetail>> GetByItemIdAsync(int itemId)
        {
            return await _transferOrderDetailRepository.GetByItemIdAsync(itemId);
        }

        public async Task AddAsync(TransferOrderDetail transferDetail)
        {
            ArgumentNullException.ThrowIfNull(transferDetail);
            await _transferOrderDetailRepository.AddAsync(transferDetail);
        }

        public async Task UpdateAsync(TransferOrderDetail transferDetail)
        {
            ArgumentNullException.ThrowIfNull(transferDetail);
            await _transferOrderDetailRepository.UpdateAsync(transferDetail);
        }
    }
}
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class IssueOrderFacade : IIssueOrderFacade
    {
        private readonly IIssueOrderRepository _issueOrderRepository;

        public IssueOrderFacade(IIssueOrderRepository issueOrderRepository)
        {
            _issueOrderRepository = issueOrderRepository;
        }

        public async Task<List<IssueOrder>> GetAllAsync()
        {
            return await _issueOrderRepository.GetAllAsync();
        }

        public async Task<IssueOrder?> GetByIdAsync(int id)
        {
            return await _issueOrderRepository.GetByIdAsync(id);
        }

        public async Task<List<IssueOrder>> GetByRequisitionIdAsync(int requisitionId)
        {
            return await _issueOrderRepository.GetByRequisitionIdAsync(requisitionId);
        }

        public async Task<List<IssueOrder>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _issueOrderRepository.GetByWarehouseIdAsync(warehouseId);
        }

        public async Task AddAsync(IssueOrder issueOrder)
        {
            ArgumentNullException.ThrowIfNull(issueOrder);
            await _issueOrderRepository.AddAsync(issueOrder);
        }

        public async Task UpdateAsync(IssueOrder issueOrder)
        {
            ArgumentNullException.ThrowIfNull(issueOrder);
            await _issueOrderRepository.UpdateAsync(issueOrder);
        }
    }
}
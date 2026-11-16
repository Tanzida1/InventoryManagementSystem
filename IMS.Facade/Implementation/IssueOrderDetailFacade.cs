using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class IssueOrderDetailFacade : IIssueOrderDetailFacade
    {
        private readonly IIssueOrderDetailRepository _issueOrderDetailRepository;

        public IssueOrderDetailFacade(IIssueOrderDetailRepository issueOrderDetailRepository)
        {
            _issueOrderDetailRepository = issueOrderDetailRepository;
        }

        public async Task<List<IssueOrderDetail>> GetAllAsync()
        {
            return await _issueOrderDetailRepository.GetAllAsync();
        }

        public async Task<IssueOrderDetail?> GetByIdAsync(int id)
        {
            return await _issueOrderDetailRepository.GetByIdAsync(id);
        }

        public async Task<List<IssueOrderDetail>> GetByIssueOrderIdAsync(int issueOrderId)
        {
            return await _issueOrderDetailRepository.GetByIssueOrderIdAsync(issueOrderId);
        }

        public async Task<List<IssueOrderDetail>> GetByRequisitionDetailIdAsync(int requisitionDetailId)
        {
            return await _issueOrderDetailRepository.GetByRequisitionDetailIdAsync(requisitionDetailId);
        }

        public async Task AddAsync(IssueOrderDetail issueOrderDetail)
        {
            ArgumentNullException.ThrowIfNull(issueOrderDetail);
            await _issueOrderDetailRepository.AddAsync(issueOrderDetail);
        }

        public async Task UpdateAsync(IssueOrderDetail issueOrderDetail)
        {
            ArgumentNullException.ThrowIfNull(issueOrderDetail);
            await _issueOrderDetailRepository.UpdateAsync(issueOrderDetail);
        }
    }
}
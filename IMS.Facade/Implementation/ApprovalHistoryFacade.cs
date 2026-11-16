
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class ApprovalHistoryFacade : IApprovalHistoryFacade
    {
        private readonly IApprovalHistoryRepository _approvalHistoryRepository;

        public ApprovalHistoryFacade(
            IApprovalHistoryRepository approvalHistoryRepository)
        {
            _approvalHistoryRepository = approvalHistoryRepository;
        }

        public async Task<List<ApprovalHistory>> GetAllAsync()
        {
            return await _approvalHistoryRepository.GetAllAsync();
        }

        public async Task<ApprovalHistory?> GetByIdAsync(int approvalHistoryId)
        {
            return await _approvalHistoryRepository.GetByIdAsync(approvalHistoryId);
        }

        public async Task<List<ApprovalHistory>> GetByDocumentAsync(
            string documentType, int documentId)
        {
            return await _approvalHistoryRepository.GetByDocumentAsync(
                documentType, documentId);
        }

        public async Task<List<ApprovalHistory>> GetByActionByAsync(int userId)
        {
            return await _approvalHistoryRepository.GetByActionByAsync(userId);
        }

        public async Task AddAsync(ApprovalHistory approvalHistory)
        {
            ArgumentNullException.ThrowIfNull(approvalHistory);

            await _approvalHistoryRepository.AddAsync(approvalHistory);
        }
    }
}

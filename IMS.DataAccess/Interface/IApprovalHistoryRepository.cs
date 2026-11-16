
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IApprovalHistoryRepository
    {
        // 1. Get all approval histories
        Task<List<ApprovalHistory>> GetAllAsync();

        // 2. Get approval history by ID
        Task<ApprovalHistory?> GetByIdAsync(int approvalHistoryId);

        // 3. Get approval history by document
        Task<List<ApprovalHistory>> GetByDocumentAsync(
            string documentType,
            int documentId);

        // 4. Get approval history by user
        Task<List<ApprovalHistory>> GetByActionByAsync(int userId);

        // 5. Add approval history
        Task AddAsync(ApprovalHistory approvalHistory);
    }
}

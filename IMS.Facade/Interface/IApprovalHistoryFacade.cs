
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Facade.Interface
{
    public interface IApprovalHistoryFacade
    {
        Task<List<ApprovalHistory>> GetAllAsync();

        Task<ApprovalHistory?> GetByIdAsync(int approvalHistoryId);

        Task<List<ApprovalHistory>> GetByDocumentAsync(
            string documentType, int documentId);

        Task<List<ApprovalHistory>> GetByActionByAsync(int userId);

        Task AddAsync(ApprovalHistory approvalHistory);
    }
}

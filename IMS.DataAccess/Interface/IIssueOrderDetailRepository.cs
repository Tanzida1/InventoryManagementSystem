
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IIssueOrderDetailRepository
    {
        // 1. Get all issue order details
        Task<List<IssueOrderDetail>> GetAllAsync();

        // 2. Get detail by ID
        Task<IssueOrderDetail?> GetByIdAsync(int id);

        // 3. Get details by issue order
        Task<List<IssueOrderDetail>> GetByIssueOrderIdAsync(int issueOrderId);

        // 4. Get details by requisition detail
        Task<List<IssueOrderDetail>> GetByRequisitionDetailIdAsync(int requisitionDetailId);

        // 5. Add issue order detail
        Task AddAsync(IssueOrderDetail issueOrderDetail);

        // 6. Update issue order detail
        Task UpdateAsync(IssueOrderDetail issueOrderDetail);
    }
}

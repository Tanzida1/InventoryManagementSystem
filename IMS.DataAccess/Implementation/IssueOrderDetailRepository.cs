
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Implementation
{
    public class IssueOrderDetailRepository : IIssueOrderDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public IssueOrderDetailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all issue order details
        public async Task<List<IssueOrderDetail>> GetAllAsync()
        {
            return await _dbContext.IssueOrderDetails
                .OrderByDescending(issueDetail => issueDetail.IssueOrderDetailId)
                .ToListAsync();
        }

        // 2. Get issue order detail by ID
        public async Task<IssueOrderDetail?> GetByIdAsync(int id)
        {
            return await _dbContext.IssueOrderDetails.FindAsync(id);
        }

        // 3. Get details by issue order ID
        public async Task<List<IssueOrderDetail>> GetByIssueOrderIdAsync(int issueOrderId)
        {
            return await _dbContext.IssueOrderDetails
                .Where(issueDetail => issueDetail.IssueOrderId == issueOrderId)
                .ToListAsync();
        }

        // 4. Get details by requisition detail ID
        public async Task<List<IssueOrderDetail>> GetByRequisitionDetailIdAsync(int requisitionDetailId)
        {
            return await _dbContext.IssueOrderDetails
                .Where(issueDetail => issueDetail.RequisitionDetailId == requisitionDetailId)
                .ToListAsync();
        }

        // 5. Add issue order detail
        public async Task AddAsync(IssueOrderDetail issueOrderDetail)
        {
            await _dbContext.IssueOrderDetails.AddAsync(issueOrderDetail);
            await _dbContext.SaveChangesAsync();
        }

        // 6. Update issue order detail
        public async Task UpdateAsync(IssueOrderDetail issueOrderDetail)
        {
            _dbContext.IssueOrderDetails.Update(issueOrderDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}

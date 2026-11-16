
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.DataAccess.Implementation
{
    public class ApprovalHistoryRepository : IApprovalHistoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ApprovalHistoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all approval histories
        public async Task<List<ApprovalHistory>> GetAllAsync()
        {
            return await _dbContext.ApprovalHistories
                .OrderByDescending(history => history.ApprovalHistoryId)
                .ToListAsync();
        }

        // 2. Get approval history by ID
        public async Task<ApprovalHistory?> GetByIdAsync(int approvalHistoryId)
        {
            return await _dbContext.ApprovalHistories
                .FindAsync(approvalHistoryId);
        }

        // 3. Get approval history by document
        public async Task<List<ApprovalHistory>> GetByDocumentAsync(
            string documentType,
            int documentId)
        {
            return await _dbContext.ApprovalHistories
                .Where(history =>
                    history.DocumentType == documentType &&
                    history.DocumentId == documentId)
                .ToListAsync();
        }

        // 4. Get approval history by user
        public async Task<List<ApprovalHistory>> GetByActionByAsync(int userId)
        {
            return await _dbContext.ApprovalHistories
                .Where(history => history.ActionBy == userId)
                .ToListAsync();
        }

        // 5. Add approval history
        public async Task AddAsync(ApprovalHistory approvalHistory)
        {
            await _dbContext.ApprovalHistories.AddAsync(approvalHistory);
            await _dbContext.SaveChangesAsync();
        }
    }
}

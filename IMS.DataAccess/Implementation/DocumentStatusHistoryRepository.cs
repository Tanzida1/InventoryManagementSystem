
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class DocumentStatusHistoryRepository : IDocumentStatusHistoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DocumentStatusHistoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all status histories
        public async Task<List<DocumentStatusHistory>> GetAllAsync()
        {
            return await _dbContext.DocumentStatusHistories
                .ToListAsync();
        }

        // 2. Get status history by ID
        public async Task<DocumentStatusHistory?> GetByIdAsync(int id)
        {
            return await _dbContext.DocumentStatusHistories
                .FindAsync(id);
        }

        // 3. Get status history by document
        public async Task<List<DocumentStatusHistory>> GetByDocumentAsync(
            string documentType,
            int documentId)
        {
            return await _dbContext.DocumentStatusHistories
                .Where(history =>
                    history.DocumentType == documentType &&
                    history.DocumentId == documentId)
                .ToListAsync();
        }

        // 4. Get status changes by user
        public async Task<List<DocumentStatusHistory>> GetByChangedByAsync(int userId)
        {
            return await _dbContext.DocumentStatusHistories
                .Where(history => history.ChangedBy == userId)
                .ToListAsync();
        }

        // 5. Add status history
        public async Task AddAsync(DocumentStatusHistory statusHistory)
        {
            await _dbContext.DocumentStatusHistories
                .AddAsync(statusHistory);

            await _dbContext.SaveChangesAsync();
        }
    }
}

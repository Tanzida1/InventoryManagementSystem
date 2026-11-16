
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class DocumentAttachmentRepository : IDocumentAttachmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DocumentAttachmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all document attachments
        public async Task<List<DocumentAttachment>> GetAllAsync()
        {
            return await _dbContext.DocumentAttachments
                .ToListAsync();
        }

        // 2. Get attachment by ID
        public async Task<DocumentAttachment?> GetByIdAsync(int attachmentId)
        {
            return await _dbContext.DocumentAttachments
                .FindAsync(attachmentId);
        }

        // 3. Get attachments by document
        public async Task<List<DocumentAttachment>> GetByDocumentAsync(
            string documentType,
            int documentId)
        {
            return await _dbContext.DocumentAttachments
                .Where(attachment =>
                    attachment.DocumentType == documentType &&
                    attachment.DocumentId == documentId)
                .ToListAsync();
        }

        // 4. Get attachments uploaded by user
        public async Task<List<DocumentAttachment>> GetByUploadedByAsync(int userId)
        {
            return await _dbContext.DocumentAttachments
                .Where(attachment => attachment.UploadedBy == userId)
                .ToListAsync();
        }

        // 5. Add attachment
        public async Task AddAsync(DocumentAttachment attachment)
        {
            await _dbContext.DocumentAttachments.AddAsync(attachment);
            await _dbContext.SaveChangesAsync();
        }

        // 6. Delete attachment metadata
        public async Task DeleteAsync(int attachmentId)
        {
            DocumentAttachment? attachment =
                await _dbContext.DocumentAttachments.FindAsync(attachmentId);

            if (attachment == null)
            {
                return;
            }

            _dbContext.DocumentAttachments.Remove(attachment);
            await _dbContext.SaveChangesAsync();
        }
    }
}

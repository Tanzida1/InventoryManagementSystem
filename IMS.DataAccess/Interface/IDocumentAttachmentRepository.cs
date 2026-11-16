
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IDocumentAttachmentRepository
    {
        // 1. Get all document attachments
        Task<List<DocumentAttachment>> GetAllAsync();

        // 2. Get attachment by ID
        Task<DocumentAttachment?> GetByIdAsync(int attachmentId);

        // 3. Get attachments by document
        Task<List<DocumentAttachment>> GetByDocumentAsync(
            string documentType,
            int documentId);

        // 4. Get attachments uploaded by user
        Task<List<DocumentAttachment>> GetByUploadedByAsync(int userId);

        // 5. Add attachment
        Task AddAsync(DocumentAttachment attachment);

        // 6. Delete attachment metadata
        Task DeleteAsync(int attachmentId);
    }
}

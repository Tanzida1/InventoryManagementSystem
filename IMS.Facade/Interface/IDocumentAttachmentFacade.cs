
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Facade.Interface
{
    public interface IDocumentAttachmentFacade
    {
        Task<List<DocumentAttachment>> GetAllAsync();

        Task<DocumentAttachment?> GetByIdAsync(int attachmentId);

        Task<List<DocumentAttachment>> GetByDocumentAsync(
            string documentType, int documentId);

        Task<List<DocumentAttachment>> GetByUploadedByAsync(int userId);

        Task AddAsync(DocumentAttachment attachment);

        Task DeleteAsync(int attachmentId);
    }
}

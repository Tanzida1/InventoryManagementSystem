
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class DocumentAttachmentFacade : IDocumentAttachmentFacade
    {
        private readonly IDocumentAttachmentRepository _documentAttachmentRepository;

        public DocumentAttachmentFacade(
            IDocumentAttachmentRepository documentAttachmentRepository)
        {
            _documentAttachmentRepository = documentAttachmentRepository;
        }

        public async Task<List<DocumentAttachment>> GetAllAsync()
        {
            return await _documentAttachmentRepository.GetAllAsync();
        }

        public async Task<DocumentAttachment?> GetByIdAsync(int attachmentId)
        {
            return await _documentAttachmentRepository.GetByIdAsync(attachmentId);
        }

        public async Task<List<DocumentAttachment>> GetByDocumentAsync(
            string documentType, int documentId)
        {
            return await _documentAttachmentRepository.GetByDocumentAsync(
                documentType, documentId);
        }

        public async Task<List<DocumentAttachment>> GetByUploadedByAsync(int userId)
        {
            return await _documentAttachmentRepository.GetByUploadedByAsync(userId);
        }

        public async Task AddAsync(DocumentAttachment attachment)
        {
            ArgumentNullException.ThrowIfNull(attachment);

            await _documentAttachmentRepository.AddAsync(attachment);
        }

        public async Task DeleteAsync(int attachmentId)
        {
            await _documentAttachmentRepository.DeleteAsync(attachmentId);
        }
    }
}

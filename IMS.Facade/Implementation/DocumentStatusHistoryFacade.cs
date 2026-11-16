
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class DocumentStatusHistoryFacade : IDocumentStatusHistoryFacade
    {
        private readonly IDocumentStatusHistoryRepository _documentStatusHistoryRepository;

        public DocumentStatusHistoryFacade(
            IDocumentStatusHistoryRepository documentStatusHistoryRepository)
        {
            _documentStatusHistoryRepository = documentStatusHistoryRepository;
        }

        // 1. Get all status histories
        public async Task<List<DocumentStatusHistory>> GetAllAsync()
        {
            return await _documentStatusHistoryRepository.GetAllAsync();
        }

        // 2. Get status history by ID
        public async Task<DocumentStatusHistory?> GetByIdAsync(int id)
        {
            return await _documentStatusHistoryRepository.GetByIdAsync(id);
        }

        // 3. Get status history by document
        public async Task<List<DocumentStatusHistory>> GetByDocumentAsync(
            string documentType, int documentId)
        {
            return await _documentStatusHistoryRepository.GetByDocumentAsync(
                documentType, documentId);
        }

        // 4. Get status changes by user
        public async Task<List<DocumentStatusHistory>> GetByChangedByAsync(int userId)
        {
            return await _documentStatusHistoryRepository.GetByChangedByAsync(userId);
        }

        // 5. Add status history
        public async Task AddAsync(DocumentStatusHistory statusHistory)
        {
            ArgumentNullException.ThrowIfNull(statusHistory);

            await _documentStatusHistoryRepository.AddAsync(statusHistory);
        }
    }
}


using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IDocumentStatusHistoryRepository
    {
        // 1. Get all status histories
        Task<List<DocumentStatusHistory>> GetAllAsync();

        // 2. Get status history by ID
        Task<DocumentStatusHistory?> GetByIdAsync(int id);

        // 3. Get status history by document
        Task<List<DocumentStatusHistory>> GetByDocumentAsync(
            string documentType,
            int documentId);

        // 4. Get status changes by user
        Task<List<DocumentStatusHistory>> GetByChangedByAsync(int userId);

        // 5. Add status history
        Task AddAsync(DocumentStatusHistory statusHistory);
    }
}

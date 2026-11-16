
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IDocumentSequenceRepository
    {
        // 1. Get all document sequences
        Task<List<DocumentSequence>> GetAllAsync();

        // 2. Get sequence by ID
        Task<DocumentSequence?> GetByIdAsync(int sequenceId);

        // 3. Get sequence by document type
        Task<DocumentSequence?> GetByDocumentTypeAsync(string documentType);

        // 4. Add new document sequence
        Task AddAsync(DocumentSequence documentSequence);

        // 5. Update document sequence
        Task UpdateAsync(DocumentSequence documentSequence);
    }
}

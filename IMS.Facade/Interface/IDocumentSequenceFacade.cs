
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Facade.Interface
{
    public interface IDocumentSequenceFacade
    {
        Task<List<DocumentSequence>> GetAllAsync();

        Task<DocumentSequence?> GetByIdAsync(int sequenceId);

        Task<DocumentSequence?> GetByDocumentTypeAsync(string documentType);

        Task AddAsync(DocumentSequence documentSequence);

        Task UpdateAsync(DocumentSequence documentSequence);
    }
}


using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class DocumentSequenceFacade : IDocumentSequenceFacade
    {
        private readonly IDocumentSequenceRepository _documentSequenceRepository;

        public DocumentSequenceFacade(
            IDocumentSequenceRepository documentSequenceRepository)
        {
            _documentSequenceRepository = documentSequenceRepository;
        }

        public async Task<List<DocumentSequence>> GetAllAsync()
        {
            return await _documentSequenceRepository.GetAllAsync();
        }

        public async Task<DocumentSequence?> GetByIdAsync(int sequenceId)
        {
            return await _documentSequenceRepository.GetByIdAsync(sequenceId);
        }

        public async Task<DocumentSequence?> GetByDocumentTypeAsync(string documentType)
        {
            return await _documentSequenceRepository.GetByDocumentTypeAsync(documentType);
        }

        public async Task AddAsync(DocumentSequence documentSequence)
        {
            ArgumentNullException.ThrowIfNull(documentSequence);

            await _documentSequenceRepository.AddAsync(documentSequence);
        }

        public async Task UpdateAsync(DocumentSequence documentSequence)
        {
            ArgumentNullException.ThrowIfNull(documentSequence);

            await _documentSequenceRepository.UpdateAsync(documentSequence);
        }
    }
}

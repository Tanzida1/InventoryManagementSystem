
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class DocumentSequenceRepository : IDocumentSequenceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DocumentSequenceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all document sequences
        public async Task<List<DocumentSequence>> GetAllAsync()
        {
            return await _dbContext.DocumentSequences.ToListAsync();
        }

        // 2. Get sequence by ID
        public async Task<DocumentSequence?> GetByIdAsync(int sequenceId)
        {
            return await _dbContext.DocumentSequences
                .FindAsync(sequenceId);
        }

        // 3. Get sequence by document type
        public async Task<DocumentSequence?> GetByDocumentTypeAsync(string documentType)
        {
            return await _dbContext.DocumentSequences
                .FirstOrDefaultAsync(sequence =>
                    sequence.DocumentType == documentType);
        }

        // 4. Add new document sequence
        public async Task AddAsync(DocumentSequence documentSequence)
        {
            await _dbContext.DocumentSequences.AddAsync(documentSequence);
            await _dbContext.SaveChangesAsync();
        }

        // 5. Update document sequence
        public async Task UpdateAsync(DocumentSequence documentSequence)
        {
            _dbContext.DocumentSequences.Update(documentSequence);
            await _dbContext.SaveChangesAsync();
        }
    }
}

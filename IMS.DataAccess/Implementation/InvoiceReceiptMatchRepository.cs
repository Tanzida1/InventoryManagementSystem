
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class InvoiceReceiptMatchRepository : IInvoiceReceiptMatchRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InvoiceReceiptMatchRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all invoice receipt matches
        public async Task<List<InvoiceReceiptMatch>> GetAllAsync()
        {
            return await _dbContext.InvoiceReceiptMatches.ToListAsync();
        }

        // 2. Get match by ID
        public async Task<InvoiceReceiptMatch?> GetByIdAsync(int id)
        {
            return await _dbContext.InvoiceReceiptMatches.FindAsync(id);
        }

        // 3. Get matches by invoice detail
        public async Task<List<InvoiceReceiptMatch>> GetByInvoiceDetailIdAsync(int invoiceDetailId)
        {
            return await _dbContext.InvoiceReceiptMatches
                .Where(match => match.InvoiceDetailId == invoiceDetailId)
                .ToListAsync();
        }

        // 4. Get matches by goods receipt detail
        public async Task<List<InvoiceReceiptMatch>> GetByGRNDetailIdAsync(int grnDetailId)
        {
            return await _dbContext.InvoiceReceiptMatches
                .Where(match => match.GRNDetailId == grnDetailId)
                .ToListAsync();
        }

        // 5. Add invoice receipt match
        public async Task AddAsync(InvoiceReceiptMatch invoiceReceiptMatch)
        {
            await _dbContext.InvoiceReceiptMatches.AddAsync(invoiceReceiptMatch);
            await _dbContext.SaveChangesAsync();
        }

        // 6. Update invoice receipt match
        public async Task UpdateAsync(InvoiceReceiptMatch invoiceReceiptMatch)
        {
            _dbContext.InvoiceReceiptMatches.Update(invoiceReceiptMatch);
            await _dbContext.SaveChangesAsync();
        }
    }
}

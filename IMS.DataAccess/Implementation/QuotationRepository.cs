using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class QuotationRepository : IQuotationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public QuotationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Quotation>> GetAllAsync()
        {
            return await _dbContext.Quotations.ToListAsync();
        }

        public async Task<Quotation?> GetByIdAsync(int id)
        {
            return await _dbContext.Quotations.FindAsync(id);
        }

        public async Task<List<Quotation>> GetBySupplierIdAsync(int supplierId)
        {
            return await _dbContext.Quotations
                .Where(quotation => quotation.SupplierId == supplierId)
                .ToListAsync();
        }

        public async Task AddAsync(Quotation quotation)
        {
            await _dbContext.Quotations.AddAsync(quotation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Quotation quotation)
        {
            _dbContext.Quotations.Update(quotation);
            await _dbContext.SaveChangesAsync();
        }
    }
}
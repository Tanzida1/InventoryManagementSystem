using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class QuotationDetailRepository : IQuotationDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public QuotationDetailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<QuotationDetail>> GetAllAsync()
        {
            return await _dbContext.QuotationDetails.ToListAsync();
        }

        public async Task<QuotationDetail?> GetByIdAsync(int id)
        {
            return await _dbContext.QuotationDetails.FindAsync(id);
        }

        public async Task<List<QuotationDetail>> GetByQuotationIdAsync(int quotationId)
        {
            return await _dbContext.QuotationDetails
                .Where(detail => detail.QuotationId == quotationId)
                .ToListAsync();
        }

        public async Task<List<QuotationDetail>> GetByItemIdAsync(int itemId)
        {
            return await _dbContext.QuotationDetails
                .Where(detail => detail.ItemId == itemId)
                .ToListAsync();
        }

        public async Task AddAsync(QuotationDetail quotationDetail)
        {
            await _dbContext.QuotationDetails.AddAsync(quotationDetail);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(QuotationDetail quotationDetail)
        {
            _dbContext.QuotationDetails.Update(quotationDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}
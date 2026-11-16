using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class SupplierInvoiceRepository : ISupplierInvoiceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SupplierInvoiceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SupplierInvoice>> GetAllAsync()
        {
            return await _dbContext.SupplierInvoices.ToListAsync();
        }

        public async Task<SupplierInvoice?> GetByIdAsync(int supplierInvoiceId)
        {
            return await _dbContext.SupplierInvoices.FindAsync(supplierInvoiceId);
        }

        public async Task<List<SupplierInvoice>> GetBySupplierIdAsync(int supplierId)
        {
            return await _dbContext.SupplierInvoices
                .Where(invoice => invoice.SupplierId == supplierId)
                .ToListAsync();
        }

        public async Task AddAsync(SupplierInvoice supplierInvoice)
        {
            await _dbContext.SupplierInvoices.AddAsync(supplierInvoice);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(SupplierInvoice supplierInvoice)
        {
            _dbContext.SupplierInvoices.Update(supplierInvoice);
            await _dbContext.SaveChangesAsync();
        }
    }
}
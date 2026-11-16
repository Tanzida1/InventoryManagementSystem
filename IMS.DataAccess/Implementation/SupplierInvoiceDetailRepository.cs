
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class SupplierInvoiceDetailRepository : ISupplierInvoiceDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SupplierInvoiceDetailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SupplierInvoiceDetail>> GetAllAsync()
        {
            return await _dbContext.SupplierInvoiceDetails.ToListAsync();
        }

        public async Task<SupplierInvoiceDetail?> GetByIdAsync(int id)
        {
            return await _dbContext.SupplierInvoiceDetails.FindAsync(id);
        }

        public async Task<List<SupplierInvoiceDetail>> GetBySupplierInvoiceIdAsync(int supplierInvoiceId)
        {
            return await _dbContext.SupplierInvoiceDetails
                .Where(detail => detail.SupplierInvoiceId == supplierInvoiceId)
                .ToListAsync();
        }

        public async Task<List<SupplierInvoiceDetail>> GetByPurchaseOrderDetailIdAsync(int poDetailId)
        {
            return await _dbContext.SupplierInvoiceDetails
                .Where(detail => detail.PODetailId == poDetailId)
                .ToListAsync();
        }



        public async Task AddAsync(SupplierInvoiceDetail supplierInvoiceDetail)
        {
            await _dbContext.SupplierInvoiceDetails.AddAsync(supplierInvoiceDetail);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(SupplierInvoiceDetail supplierInvoiceDetail)
        {
            _dbContext.SupplierInvoiceDetails.Update(supplierInvoiceDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}

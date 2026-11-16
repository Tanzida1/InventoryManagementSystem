
using IMS.DataAccess.Interface;
using IMS.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Implementation
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SupplierRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all suppliers
        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _dbContext.Suppliers
                .OrderByDescending(supplier => supplier.SupplierId)
                .ToListAsync();
        }

        // 2. Get supplier by ID
        public async Task<Supplier?> GetByIdAsync(int supplierId)
        {
            return await _dbContext.Suppliers.FindAsync(supplierId);
        }

        // 3. Add supplier
        public async Task AddAsync(Supplier supplier)
        {
            await _dbContext.Suppliers.AddAsync(supplier);
            await _dbContext.SaveChangesAsync();
        }

        // 4. Update supplier
        public async Task UpdateAsync(Supplier supplier)
        {
            _dbContext.Suppliers.Update(supplier);
            await _dbContext.SaveChangesAsync();
        }

        // 5. Delete supplier
        public async Task DeleteAsync(int supplierId)
        {
            var supplier = await _dbContext.Suppliers.FindAsync(supplierId);

            if (supplier == null)
                return;

            _dbContext.Suppliers.Remove(supplier);
            await _dbContext.SaveChangesAsync();
        }
    }
}

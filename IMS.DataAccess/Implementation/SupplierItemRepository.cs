
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
    public class SupplierItemRepository : ISupplierItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SupplierItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all supplier items
        public async Task<List<SupplierItem>> GetAllAsync()
        {
            return await _dbContext.SupplierItems
                .OrderByDescending(supplierItem => supplierItem.SupplierItemId)
                .ToListAsync();
        }

        // 2. Get supplier item by ID
        public async Task<SupplierItem?> GetByIdAsync(int supplierItemId)
        {
            return await _dbContext.SupplierItems.FindAsync(supplierItemId);
        }

        // 3. Get items by supplier ID
        public async Task<List<SupplierItem>> GetBySupplierIdAsync(int supplierId)
        {
            return await _dbContext.SupplierItems
                .Where(supplierItem => supplierItem.SupplierId == supplierId)
                .ToListAsync();
        }

        // 4. Add supplier item
        public async Task AddAsync(SupplierItem supplierItem)
        {
            await _dbContext.SupplierItems.AddAsync(supplierItem);
            await _dbContext.SaveChangesAsync();
        }

        // 5. Update supplier item
        public async Task UpdateAsync(SupplierItem supplierItem)
        {
            _dbContext.SupplierItems.Update(supplierItem);
            await _dbContext.SaveChangesAsync();
        }

        // 6. Delete supplier item
        public async Task DeleteAsync(int supplierItemId)
        {
            var supplierItem = await _dbContext.SupplierItems
                .FindAsync(supplierItemId);

            if (supplierItem == null)
                return;

            _dbContext.SupplierItems.Remove(supplierItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}

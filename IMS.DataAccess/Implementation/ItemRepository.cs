
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
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all items
        public async Task<List<Item>> GetAllAsync()
        {
            return await _dbContext.Items
                .OrderByDescending(item => item.ItemId)
                .ToListAsync();
        }

        // 2. Get item by ID
        public async Task<Item?> GetByIdAsync(int itemId)
        {
            return await _dbContext.Items.FindAsync(itemId);
        }

        // 3. Get items by category ID
        public async Task<List<Item>> GetByCategoryIdAsync(int categoryId)
        {
            return await _dbContext.Items
                .Where(item => item.CategoryId == categoryId)
                .ToListAsync();
        }

        // 4. Add item
        public async Task AddAsync(Item item)
        {
            await _dbContext.Items.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        // 5. Update item
        public async Task UpdateAsync(Item item)
        {
            _dbContext.Items.Update(item);
            await _dbContext.SaveChangesAsync();
        }

        // 6. Delete item
        public async Task DeleteAsync(int itemId)
        {
            var item = await _dbContext.Items.FindAsync(itemId);

            if (item == null)
                return;

            _dbContext.Items.Remove(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}

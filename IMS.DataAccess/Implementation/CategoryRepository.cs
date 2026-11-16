
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all categories
        public async Task<List<Category>> GetAllAsync()
        {
            return await _dbContext.Categories
                .OrderByDescending(category => category.CategoryId)
                .ToListAsync();
        }

        // 2. Get category by ID
        public async Task<Category?> GetByIdAsync(int categoryId)
        {
            return await _dbContext.Categories.FindAsync(categoryId);
        }

        // 3. Add category
        public async Task AddAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
        }

        // 4. Update category
        public async Task UpdateAsync(Category category)
        {
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
        }

        // 5. Delete category
        public async Task DeleteAsync(int categoryId)
        {
            var category = await _dbContext.Categories.FindAsync(categoryId);

            if (category == null)
                return;

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}

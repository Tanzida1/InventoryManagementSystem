
using IMS.Entities;
using IMS.Entities.Inventory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface ICategoryRepository
    {
        // 1. Get all categories
        Task<List<Category>> GetAllAsync();

        // 2. Get category by ID
        Task<Category?> GetByIdAsync(int categoryId);

        // 3. Add category
        Task AddAsync(Category category);

        // 4. Update category
        Task UpdateAsync(Category category);

        // 5. Delete category
        Task DeleteAsync(int categoryId);
    }
}

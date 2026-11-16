
using IMS.Entities;
using IMS.Entities.Inventory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Facade.Interface
{
    public interface ICategoryFacade
    {
        Task<List<Category>> GetAllAsync();

        Task<Category?> GetByIdAsync(int categoryId);

        Task AddAsync(Category category);

        Task UpdateAsync(Category category);

        Task DeleteAsync(int categoryId);
    }
}

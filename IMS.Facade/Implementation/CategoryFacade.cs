
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Entities.Inventory;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class CategoryFacade : ICategoryFacade
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryFacade(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category?> GetByIdAsync(int categoryId)
        {
            return await _categoryRepository.GetByIdAsync(categoryId);
        }

        public async Task AddAsync(Category category)
        {
            ArgumentNullException.ThrowIfNull(category);

            await _categoryRepository.AddAsync(category);
        }

        public async Task UpdateAsync(Category category)
        {
            ArgumentNullException.ThrowIfNull(category);

            await _categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteAsync(int categoryId)
        {
            await _categoryRepository.DeleteAsync(categoryId);
        }
    }
}

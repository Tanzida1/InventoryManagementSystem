using IMS.DataAccess.Interface;
using IMS.Entities.Inventory;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class ItemFacade : IItemFacade
    {
        private readonly IItemRepository _itemRepository;

        public ItemFacade(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _itemRepository.GetAllAsync();
        }

        public async Task<Item?> GetByIdAsync(int itemId)
        {
            return await _itemRepository.GetByIdAsync(itemId);
        }

        public async Task<List<Item>> GetByCategoryIdAsync(int categoryId)
        {
            return await _itemRepository.GetByCategoryIdAsync(categoryId);
        }

        public async Task AddAsync(Item item)
        {
            ArgumentNullException.ThrowIfNull(item);
            await _itemRepository.AddAsync(item);
        }

        public async Task UpdateAsync(Item item)
        {
            ArgumentNullException.ThrowIfNull(item);
            await _itemRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int itemId)
        {
            await _itemRepository.DeleteAsync(itemId);
        }
    }
}
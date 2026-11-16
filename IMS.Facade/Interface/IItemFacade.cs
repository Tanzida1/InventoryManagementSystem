using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
  public  interface IItemFacade
    {

        // 1. Get all items
        Task<List<Item>> GetAllAsync();

        // 2. Get item by ID
        Task<Item?> GetByIdAsync(int itemId);

        // 3. Get items by category
        Task<List<Item>> GetByCategoryIdAsync(int categoryId);

        // 4. Add new item
        Task AddAsync(Item item);

        // 5. Update item
        Task UpdateAsync(Item item);

        // 6. Delete item
        Task DeleteAsync(int itemId);
    }
}

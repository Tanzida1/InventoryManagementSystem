using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public  interface ISupplierItemFacade
    {
        // 1. Get all supplier items
        Task<List<SupplierItem>> GetAllAsync();

        // 2. Get supplier item by ID
        Task<SupplierItem?> GetByIdAsync(int supplierItemId);

        // 3. Get items supplied by a supplier
        Task<List<SupplierItem>> GetBySupplierIdAsync(int supplierId);

        // 4. Add supplier item
        Task AddAsync(SupplierItem supplierItem);

        // 5. Update supplier item
        Task UpdateAsync(SupplierItem supplierItem);

        // 6. Remove supplier item
        Task DeleteAsync(int supplierItemId);

    }
}

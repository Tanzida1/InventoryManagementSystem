using IMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public  interface IPhysicalStockCountDetailFacade
    {

        // 1. Get all physical count details
        Task<List<PhysicalStockCountDetail>> GetAllAsync();

        // 2. Get detail by ID
        Task<PhysicalStockCountDetail?> GetByIdAsync(int id);

        // 3. Get details by physical count
        Task<List<PhysicalStockCountDetail>> GetByCountIdAsync(int countId);

        // 4. Get details by item
        Task<List<PhysicalStockCountDetail>> GetByItemIdAsync(int itemId);

        // 5. Add physical count detail
        Task AddAsync(PhysicalStockCountDetail physicalStockCountDetail);

        // 6. Update physical count detail
        Task UpdateAsync(PhysicalStockCountDetail physicalStockCountDetail);

    }
}

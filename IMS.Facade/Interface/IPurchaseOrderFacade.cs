using IMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public  interface IPurchaseOrderFacade
    {
        // 1. Get all purchase orders
        Task<List<PurchaseOrder>> GetAllAsync();

        // 2. Get purchase order by ID
        Task<PurchaseOrder?> GetByIdAsync(int id);

        // 3. Get purchase orders by supplier
        Task<List<PurchaseOrder>> GetBySupplierIdAsync(int supplierId);

        // 4. Get purchase orders by warehouse
        Task<List<PurchaseOrder>> GetByWarehouseIdAsync(int warehouseId);

        // 5. Add new purchase order
        Task AddAsync(PurchaseOrder purchaseOrder);

        // 6. Update purchase order
        Task UpdateAsync(PurchaseOrder purchaseOrder);
    }
}

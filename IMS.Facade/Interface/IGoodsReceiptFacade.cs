using IMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
   public  interface IGoodsReceiptFacade
    {

        // 1. Get all goods receipts
        Task<List<GoodsReceipt>> GetAllAsync();

        // 2. Get goods receipt by ID
        Task<GoodsReceipt?> GetByIdAsync(int id);

        // 3. Get receipts by purchase order
        Task<List<GoodsReceipt>> GetByPurchaseOrderIdAsync(int purchaseOrderId);

        // 4. Add goods receipt
        Task AddAsync(GoodsReceipt goodsReceipt);

        // 5. Update goods receipt
        Task UpdateAsync(GoodsReceipt goodsReceipt);

    }
}

using IMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public  interface IGoodsReceiptDetailFacade
    {

        Task<List<GoodsReceiptDetail>> GetAllAsync();

        Task<GoodsReceiptDetail?> GetByIdAsync(int id);

        Task<List<GoodsReceiptDetail>> GetByGoodsReceiptIdAsync(int goodsReceiptId);

        Task<List<GoodsReceiptDetail>> GetByPODetailIdAsync(int poDetailId);

        Task AddAsync(GoodsReceiptDetail goodsReceiptDetail);

        Task UpdateAsync(GoodsReceiptDetail goodsReceiptDetail);

    }
}

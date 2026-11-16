
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Implementation
{
    public class StockRequisitionDetailRepository : IStockRequisitionDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StockRequisitionDetailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all requisition details
        public async Task<List<StockRequisitionDetail>> GetAllAsync()
        {
            return await _dbContext.StockRequisitionDetails
                .OrderByDescending(detail => detail.RequisitionDetailId)
                .ToListAsync();
        }

        // 2. Get requisition detail by ID
        public async Task<StockRequisitionDetail?> GetByIdAsync(int requisitionDetailId)
        {
            return await _dbContext.StockRequisitionDetails
                .FindAsync(requisitionDetailId);
        }

        // 3. Get details by requisition ID
        public async Task<List<StockRequisitionDetail>> GetByRequisitionIdAsync(int requisitionId)
        {
            return await _dbContext.StockRequisitionDetails
                .Where(detail => detail.RequisitionId == requisitionId)
                .ToListAsync();
        }

        // 4. Get details by item ID
        public async Task<List<StockRequisitionDetail>> GetByItemIdAsync(int itemId)
        {
            return await _dbContext.StockRequisitionDetails
                .Where(detail => detail.ItemId == itemId)
                .ToListAsync();
        }

        // 5. Add requisition detail
        public async Task AddAsync(StockRequisitionDetail requisitionDetail)
        {
            await _dbContext.StockRequisitionDetails.AddAsync(requisitionDetail);
            await _dbContext.SaveChangesAsync();
        }

        // 6. Update requisition detail
        public async Task UpdateAsync(StockRequisitionDetail requisitionDetail)
        {
            _dbContext.StockRequisitionDetails.Update(requisitionDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}

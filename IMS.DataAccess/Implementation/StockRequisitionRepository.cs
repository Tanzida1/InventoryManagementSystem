
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
    public class StockRequisitionRepository : IStockRequisitionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StockRequisitionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all stock requisitions
        public async Task<List<StockRequisition>> GetAllAsync()
        {
            return await _dbContext.StockRequisitions
                .OrderByDescending(requisition => requisition.RequisitionId)
                .ToListAsync();
        }

        // 2. Get requisition by ID
        public async Task<StockRequisition?> GetByIdAsync(int requisitionId)
        {
            return await _dbContext.StockRequisitions.FindAsync(requisitionId);
        }

        // 3. Get requisitions by requester ID
        public async Task<List<StockRequisition>> GetByRequesterIdAsync(int requesterId)
        {
            return await _dbContext.StockRequisitions
               .Where(requisition => requisition.RequesterId == requesterId)
                .ToListAsync();
        }

        // 4. Get requisitions by warehouse ID
        public async Task<List<StockRequisition>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _dbContext.StockRequisitions
                .Where(requisition => requisition.WarehouseId == warehouseId)
                .ToListAsync();
        }

        // 5. Add requisition
        public async Task AddAsync(StockRequisition requisition)
        {
            await _dbContext.StockRequisitions.AddAsync(requisition);
            await _dbContext.SaveChangesAsync();
        }

        // 6. Update requisition
        public async Task UpdateAsync(StockRequisition requisition)
        {
            _dbContext.StockRequisitions.Update(requisition);
            await _dbContext.SaveChangesAsync();
        }
    }
}

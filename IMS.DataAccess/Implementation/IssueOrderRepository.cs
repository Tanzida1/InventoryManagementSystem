
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
    public class IssueOrderRepository : IIssueOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public IssueOrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all issue orders
        public async Task<List<IssueOrder>> GetAllAsync()
        {
            return await _dbContext.IssueOrders
                .OrderByDescending(issueOrder => issueOrder.IssueOrderId)
                .ToListAsync();
        }

        // 2. Get issue order by ID
        public async Task<IssueOrder?> GetByIdAsync(int id)
        {
            return await _dbContext.IssueOrders.FindAsync(id);
        }

        // 3. Get issue orders by requisition ID
        public async Task<List<IssueOrder>> GetByRequisitionIdAsync(int requisitionId)
        {
            return await _dbContext.IssueOrders
                .Where(issueOrder => issueOrder.RequisitionId == requisitionId)
                .ToListAsync();
        }

        // 4. Get issue orders by warehouse ID
        public async Task<List<IssueOrder>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _dbContext.IssueOrders
                .Where(issueOrder => issueOrder.WarehouseId == warehouseId)
                .ToListAsync();
        }

        // 5. Add issue order
        public async Task AddAsync(IssueOrder issueOrder)
        {
            await _dbContext.IssueOrders.AddAsync(issueOrder);
            await _dbContext.SaveChangesAsync();
        }

        // 6. Update issue order
        public async Task UpdateAsync(IssueOrder issueOrder)
        {
            _dbContext.IssueOrders.Update(issueOrder);
            await _dbContext.SaveChangesAsync();
        }
    }
}

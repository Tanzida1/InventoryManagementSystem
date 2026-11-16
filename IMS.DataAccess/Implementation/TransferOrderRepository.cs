
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
    public class TransferOrderRepository : ITransferOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TransferOrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all transfer orders
        public async Task<List<TransferOrder>> GetAllAsync()
        {
            return await _dbContext.TransferOrders
                .OrderByDescending(transferOrder => transferOrder.TransferOrderId)
                .ToListAsync();
        }

        // 2. Get transfer order by ID
        public async Task<TransferOrder?> GetByIdAsync(int transferOrderId)
        {
            return await _dbContext.TransferOrders.FindAsync(transferOrderId);
        }

        // 3. Get transfer orders by source warehouse
        public async Task<List<TransferOrder>> GetBySourceWarehouseIdAsync(int warehouseId)
        {
            return await _dbContext.TransferOrders
                .Where(transferOrder => transferOrder.SourceWarehouseId == warehouseId)
                .ToListAsync();
        }

        // 4. Get transfer orders by destination warehouse
        public async Task<List<TransferOrder>> GetByDestinationWarehouseIdAsync(int warehouseId)
        {
            return await _dbContext.TransferOrders
                .Where(transferOrder => transferOrder.DestinationWarehouseId == warehouseId)
                .ToListAsync();
        }

        // 5. Get transfer orders by requester
        public async Task<List<TransferOrder>> GetByRequesterIdAsync(int requesterId)
        {
            return await _dbContext.TransferOrders
                .Where(transferOrder => transferOrder.RequestedBy == requesterId)
                .ToListAsync();
        }

        // 6. Add transfer order
        public async Task AddAsync(TransferOrder transferOrder)
        {
            await _dbContext.TransferOrders.AddAsync(transferOrder);
            await _dbContext.SaveChangesAsync();
        }

        // 7. Update transfer order
        public async Task UpdateAsync(TransferOrder transferOrder)
        {
            _dbContext.TransferOrders.Update(transferOrder);
            await _dbContext.SaveChangesAsync();
        }
    }
}

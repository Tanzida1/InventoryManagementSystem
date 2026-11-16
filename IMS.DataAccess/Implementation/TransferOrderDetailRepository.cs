
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
    public class TransferOrderDetailRepository : ITransferOrderDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TransferOrderDetailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all transfer order details
        public async Task<List<TransferOrderDetail>> GetAllAsync()
        {
            return await _dbContext.TransferOrderDetails
                .OrderByDescending(transferDetail => transferDetail.TransferDetailId)
                .ToListAsync();
        }

        // 2. Get transfer detail by ID
        public async Task<TransferOrderDetail?> GetByIdAsync(int transferDetailId)
        {
            return await _dbContext.TransferOrderDetails.FindAsync(transferDetailId);
        }

        // 3. Get details by transfer order ID
        public async Task<List<TransferOrderDetail>> GetByTransferOrderIdAsync(int transferOrderId)
        {
            return await _dbContext.TransferOrderDetails
                .Where(transferDetail => transferDetail.TransferOrderId == transferOrderId)
                .ToListAsync();
        }

        // 4. Get details by item ID
        public async Task<List<TransferOrderDetail>> GetByItemIdAsync(int itemId)
        {
            return await _dbContext.TransferOrderDetails
                .Where(transferDetail => transferDetail.ItemId == itemId)
                .ToListAsync();
        }

        // 5. Add transfer detail
        public async Task AddAsync(TransferOrderDetail transferDetail)
        {
            await _dbContext.TransferOrderDetails.AddAsync(transferDetail);
            await _dbContext.SaveChangesAsync();
        }

        // 6. Update transfer detail
        public async Task UpdateAsync(TransferOrderDetail transferDetail)
        {
            _dbContext.TransferOrderDetails.Update(transferDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}

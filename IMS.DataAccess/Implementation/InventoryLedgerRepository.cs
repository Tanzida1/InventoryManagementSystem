
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class InventoryLedgerRepository : IInventoryLedgerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InventoryLedgerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<InventoryLedger>> GetAllAsync()
        {
            return await _dbContext.InventoryLedgers
                .OrderByDescending(ledger => ledger.LedgerId)
                .ToListAsync();
        }

        public async Task<InventoryLedger?> GetByIdAsync(int id)
        {
            return await _dbContext.InventoryLedgers.FindAsync(id);
        }

        public async Task<List<InventoryLedger>> GetByItemIdAsync(int itemId)
        {
            return await _dbContext.InventoryLedgers
                .Where(ledger => ledger.ItemId == itemId)
                .ToListAsync();
        }
        // 5. Get ledger records by document
        public async Task<List<InventoryLedger>> GetByDocumentAsync(
            string documentType,
            int documentId)
        {
            return await _dbContext.InventoryLedgers
                .Where(ledger =>
                    ledger.DocumentType == documentType &&
                    ledger.DocumentId == documentId)
                .ToListAsync();
        }

        public async Task<List<InventoryLedger>> GetByDateRangeAsync(
      DateTime startDate,
      DateTime endDate)
        {
            return await _dbContext.InventoryLedgers
                .Where(ledger =>
                    ledger.TransactionDate >= startDate &&
                    ledger.TransactionDate <= endDate)
                .ToListAsync();
        }
        public async Task<List<InventoryLedger>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _dbContext.InventoryLedgers
                .Where(ledger => ledger.WarehouseId == warehouseId)
                .ToListAsync();
        }

        public async Task AddAsync(InventoryLedger inventoryLedger)
        {
            await _dbContext.InventoryLedgers.AddAsync(inventoryLedger);
            await _dbContext.SaveChangesAsync();
        }
    }
}

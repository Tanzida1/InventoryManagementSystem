
using IMS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IInventoryLedgerRepository
    {
        // 1. Get all ledger records
        Task<List<InventoryLedger>> GetAllAsync();

        // 2. Get ledger record by ID
        Task<InventoryLedger?> GetByIdAsync(int id);

        // 3. Get ledger history by item
        Task<List<InventoryLedger>> GetByItemIdAsync(int itemId);

        // 4. Get ledger history by warehouse
        Task<List<InventoryLedger>> GetByWarehouseIdAsync(int warehouseId);

        // 5. Get ledger records by document
        Task<List<InventoryLedger>> GetByDocumentAsync(
            string documentType,
            int documentId);

        // 6. Get ledger records within a date range
        Task<List<InventoryLedger>> GetByDateRangeAsync(
            DateTime startDate,
            DateTime endDate);

        // 7. Add ledger transaction
        Task AddAsync(InventoryLedger inventoryLedger);
    }
}

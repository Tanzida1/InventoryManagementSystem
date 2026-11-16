
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Facade.Implementation
{
    public class InventoryLedgerFacade : IInventoryLedgerFacade
    {
        private readonly IInventoryLedgerRepository _inventoryLedgerRepository;

        public InventoryLedgerFacade(
            IInventoryLedgerRepository inventoryLedgerRepository)
        {
            _inventoryLedgerRepository = inventoryLedgerRepository;
        }

        // 1. Get all ledger records
        public async Task<List<InventoryLedger>> GetAllAsync()
        {
            return await _inventoryLedgerRepository.GetAllAsync();
        }

        // 2. Get ledger record by ID
        public async Task<InventoryLedger?> GetByIdAsync(int id)
        {
            return await _inventoryLedgerRepository.GetByIdAsync(id);
        }

        // 3. Get ledger history by item
        public async Task<List<InventoryLedger>> GetByItemIdAsync(int itemId)
        {
            return await _inventoryLedgerRepository.GetByItemIdAsync(itemId);
        }

        // 4. Get ledger history by warehouse
        public async Task<List<InventoryLedger>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _inventoryLedgerRepository.GetByWarehouseIdAsync(warehouseId);
        }

        // 5. Get ledger records by document
        public async Task<List<InventoryLedger>> GetByDocumentAsync(
            string documentType, int documentId)
        {
            return await _inventoryLedgerRepository.GetByDocumentAsync(
                documentType, documentId);
        }

        // 6. Get ledger records within a date range
        public async Task<List<InventoryLedger>> GetByDateRangeAsync(
            DateTime startDate, DateTime endDate)
        {
            return await _inventoryLedgerRepository.GetByDateRangeAsync(
                startDate, endDate);
        }

        // 7. Add ledger transaction
        public async Task AddAsync(InventoryLedger inventoryLedger)
        {
            ArgumentNullException.ThrowIfNull(inventoryLedger);

            await _inventoryLedgerRepository.AddAsync(inventoryLedger);
        }
    }
}

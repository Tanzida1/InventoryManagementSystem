
using IMS.DataAccess.Interface;
using IMS.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Implementation
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public WarehouseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all warehouses
        public async Task<List<Warehouse>> GetAllAsync()
        {
            return await _dbContext.Warehouses
                .OrderByDescending(warehouse => warehouse.WarehouseId)
                .ToListAsync();
        }

        // 2. Get warehouse by ID
        public async Task<Warehouse?> GetByIdAsync(int warehouseId)
        {
            return await _dbContext.Warehouses.FindAsync(warehouseId);
        }

        // 3. Add warehouse
        public async Task AddAsync(Warehouse warehouse)
        {
            await _dbContext.Warehouses.AddAsync(warehouse);
            await _dbContext.SaveChangesAsync();
        }

        // 4. Update warehouse
        public async Task UpdateAsync(Warehouse warehouse)
        {
            _dbContext.Warehouses.Update(warehouse);
            await _dbContext.SaveChangesAsync();
        }

        // 5. Delete warehouse
        public async Task DeleteAsync(int warehouseId)
        {
            var warehouse = await _dbContext.Warehouses.FindAsync(warehouseId);

            if (warehouse == null)
                return;

            _dbContext.Warehouses.Remove(warehouse);
            await _dbContext.SaveChangesAsync();
        }
    }
}

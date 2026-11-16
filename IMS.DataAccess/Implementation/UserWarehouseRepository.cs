
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Entities.Access;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Implementation
{
    public class UserWarehouseRepository : IUserWarehouseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserWarehouseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all user warehouse assignments
        public async Task<List<UserWarehouse>> GetAllAsync()
        {
            return await _dbContext.UserWarehouses
                .OrderByDescending(userWarehouse => userWarehouse.UserWarehouseId)
                .ToListAsync();
        }

        // 2. Get assignment by ID
        public async Task<UserWarehouse?> GetByIdAsync(int userWarehouseId)
        {
            return await _dbContext.UserWarehouses.FindAsync(userWarehouseId);
        }

        // 3. Get warehouses assigned to a user
        public async Task<List<UserWarehouse>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.UserWarehouses
                .Where(userWarehouse => userWarehouse.UserId == userId)
                .ToListAsync();
        }

        // 4. Get users assigned to a warehouse
        public async Task<List<UserWarehouse>> GetByWarehouseIdAsync(int warehouseId)
        {
            return await _dbContext.UserWarehouses
                .Where(userWarehouse => userWarehouse.WarehouseId == warehouseId)
                .ToListAsync();
        }

        // 5. Assign warehouse to user
        public async Task AddAsync(UserWarehouse userWarehouse)
        {
            await _dbContext.UserWarehouses.AddAsync(userWarehouse);
            await _dbContext.SaveChangesAsync();
        }

        // 6. Update assignment
        public async Task UpdateAsync(UserWarehouse userWarehouse)
        {
            _dbContext.UserWarehouses.Update(userWarehouse);
            await _dbContext.SaveChangesAsync();
        }

        // 7. Remove warehouse assignment
        public async Task DeleteAsync(int userWarehouseId)
        {
            var userWarehouse = await _dbContext.UserWarehouses
                .FindAsync(userWarehouseId);

            if (userWarehouse == null)
                return;

            _dbContext.UserWarehouses.Remove(userWarehouse);
            await _dbContext.SaveChangesAsync();
        }
    }
}

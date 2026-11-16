
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Implementation
{
    public class UnitRepository : IUnitRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all units
        public async Task<List<Unit>> GetAllAsync()
        {
            return await _dbContext.Units
                .OrderByDescending(unit => unit.UnitId)
                .ToListAsync();
        }

        // 2. Get unit by ID
        public async Task<Unit?> GetByIdAsync(int unitId)
        {
            return await _dbContext.Units.FindAsync(unitId);
        }

        // 3. Add unit
        public async Task AddAsync(Unit unit)
        {
            await _dbContext.Units.AddAsync(unit);
            await _dbContext.SaveChangesAsync();
        }

        // 4. Update unit
        public async Task UpdateAsync(Unit unit)
        {
            _dbContext.Units.Update(unit);
            await _dbContext.SaveChangesAsync();
        }

        // 5. Delete unit
        public async Task DeleteAsync(int unitId)
        {
            var unit = await _dbContext.Units.FindAsync(unitId);

            if (unit == null)
                return;

            _dbContext.Units.Remove(unit);
            await _dbContext.SaveChangesAsync();
        }
    }
}

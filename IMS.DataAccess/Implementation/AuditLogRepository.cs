
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.DataAccess.Implementation
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AuditLogRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all audit logs
        public async Task<List<AuditLog>> GetAllAsync()
        {
            return await _dbContext.AuditLogs
                .OrderByDescending(log => log.AuditLogId)
                .ToListAsync();
        }

        // 2. Get audit log by ID
        public async Task<AuditLog?> GetByIdAsync(int auditLogId)
        {
            return await _dbContext.AuditLogs
                .FindAsync(auditLogId);
        }

        // 3. Get logs by user
        public async Task<List<AuditLog>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.AuditLogs
                .Where(log => log.UserId == userId)
                .ToListAsync();
        }

        // 4. Get logs by entity and record
        public async Task<List<AuditLog>> GetByEntityAsync(
            string entityName,
            int recordId)
        {
            return await _dbContext.AuditLogs
                .Where(log =>
                    log.EntityName == entityName &&
                    log.RecordId == recordId)
                .ToListAsync();
        }

        // 5. Add audit log
        public async Task AddAsync(AuditLog auditLog)
        {
            await _dbContext.AuditLogs.AddAsync(auditLog);
            await _dbContext.SaveChangesAsync();
        }
    }
}

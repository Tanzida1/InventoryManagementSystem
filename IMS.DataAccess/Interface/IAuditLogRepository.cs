
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IAuditLogRepository
    {
        // 1. Get all audit logs
        Task<List<AuditLog>> GetAllAsync();

        // 2. Get audit log by ID
        Task<AuditLog?> GetByIdAsync(int auditLogId);

        // 3. Get logs by user
        Task<List<AuditLog>> GetByUserIdAsync(int userId);

        // 4. Get logs by entity and record
        Task<List<AuditLog>> GetByEntityAsync(
            string entityName,
            int recordId);

        // 5. Add audit log
        Task AddAsync(AuditLog auditLog);
    }
}

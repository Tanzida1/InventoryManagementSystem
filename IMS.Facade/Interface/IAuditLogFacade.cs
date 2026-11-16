
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Facade.Interface
{
    public interface IAuditLogFacade
    {
        Task<List<AuditLog>> GetAllAsync();

        Task<AuditLog?> GetByIdAsync(int auditLogId);

        Task<List<AuditLog>> GetByUserIdAsync(int userId);

        Task<List<AuditLog>> GetByEntityAsync(
            string entityName, int recordId);

        Task AddAsync(AuditLog auditLog);
    }
}

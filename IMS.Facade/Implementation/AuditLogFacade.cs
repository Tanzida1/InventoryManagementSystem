
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class AuditLogFacade : IAuditLogFacade
    {
        private readonly IAuditLogRepository _auditLogRepository;

        public AuditLogFacade(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public async Task<List<AuditLog>> GetAllAsync()
        {
            return await _auditLogRepository.GetAllAsync();
        }

        public async Task<AuditLog?> GetByIdAsync(int auditLogId)
        {
            return await _auditLogRepository.GetByIdAsync(auditLogId);
        }

        public async Task<List<AuditLog>> GetByUserIdAsync(int userId)
        {
            return await _auditLogRepository.GetByUserIdAsync(userId);
        }

        public async Task<List<AuditLog>> GetByEntityAsync(
            string entityName, int recordId)
        {
            return await _auditLogRepository.GetByEntityAsync(
                entityName, recordId);
        }

        public async Task AddAsync(AuditLog auditLog)
        {
            ArgumentNullException.ThrowIfNull(auditLog);

            await _auditLogRepository.AddAsync(auditLog);
        }
    }
}

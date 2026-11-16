using IMS.Entities.Access;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }

        public int? UserId { get; set; }

        public string Action { get; set; } = string.Empty;

        public string EntityName { get; set; } = string.Empty;

        public int RecordId { get; set; }

        public string? OldValues { get; set; }

        public string? NewValues { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        // Navigation Property
        public User? User { get; set; }
    }
}

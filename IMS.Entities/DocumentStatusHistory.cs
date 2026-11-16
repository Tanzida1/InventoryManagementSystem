using IMS.Entities.Access;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Entities
{
    public class DocumentStatusHistory
    {
        public int DocumentStatusHistoryId { get; set; }

        public string DocumentType { get; set; } = string.Empty;

        public int DocumentId { get; set; }

        public string PreviousStatus { get; set; } = string.Empty;

        public string NewStatus { get; set; } = string.Empty;

        public int ChangedBy { get; set; }

        public DateTime ChangedAt { get; set; } = DateTime.Now;

        public string? Remarks { get; set; }


        // Navigation Property
        public User User { get; set; } = null!;
    }
}

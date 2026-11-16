using IMS.Entities.Access;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class ApprovalHistory
    {
        public int ApprovalHistoryId { get; set; }

        public string DocumentType { get; set; } = string.Empty;

        public int DocumentId { get; set; }

        public int ActionBy { get; set; }

        public string Decision { get; set; } = string.Empty;

        public string? Comments { get; set; }

        public DateTime ActionDate { get; set; } = DateTime.Now;


        // Navigation Property
        public User User { get; set; } = null!;
    }
}

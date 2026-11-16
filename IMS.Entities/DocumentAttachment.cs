using IMS.Entities.Access;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class DocumentAttachment
    {
        public int AttachmentId { get; set; }

        public string DocumentType { get; set; } = string.Empty;

        public int DocumentId { get; set; }

        public string FileName { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;

        public int UploadedBy { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.Now;


        // Navigation Property
        public User User { get; set; } = null!;
    }
}

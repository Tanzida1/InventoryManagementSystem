using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class DocumentSequence
    {
        public int SequenceId { get; set; }

        public string DocumentType { get; set; } = string.Empty;

        public string Prefix { get; set; } = string.Empty;

        public int NextNumber { get; set; } = 1;
    }
}

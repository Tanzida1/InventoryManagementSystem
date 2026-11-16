using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class AssistantMessage
    {
        public int MessageId { get; set; }

        public int ConversationId { get; set; }

        public string SenderType { get; set; } = string.Empty;

        public string MessageText { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        // Navigation Property
        public AssistantConversation AssistantConversation { get; set; } = null!;
    }
}

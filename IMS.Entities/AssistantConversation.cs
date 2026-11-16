using IMS.Entities.Access;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class AssistantConversation
    {
        public int ConversationId { get; set; }

        public int UserId { get; set; }

        public DateTime StartedAt { get; set; } = DateTime.Now;


        // Navigation Properties
        public User User { get; set; } = null!;

        public ICollection<AssistantMessage> AssistantMessages { get; set; }
            = new List<AssistantMessage>();
    }
}

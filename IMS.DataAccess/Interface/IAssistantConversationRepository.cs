
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IAssistantConversationRepository
    {
        // 1. Get all conversations
        Task<List<AssistantConversation>> GetAllAsync();

        // 2. Get conversation by ID
        Task<AssistantConversation?> GetByIdAsync(int conversationId);

        // 3. Get conversations by user
        Task<List<AssistantConversation>> GetByUserIdAsync(int userId);

        // 4. Start new conversation
        Task AddAsync(AssistantConversation conversation);

        // 5. Update conversation
        Task UpdateAsync(AssistantConversation conversation);
    }
}

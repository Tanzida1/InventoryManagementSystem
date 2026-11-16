
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DataAccess.Interface
{
    public interface IAssistantMessageRepository
    {
        // 1. Get all assistant messages
        Task<List<AssistantMessage>> GetAllAsync();

        // 2. Get message by ID
        Task<AssistantMessage?> GetByIdAsync(int messageId);

        // 3. Get messages by conversation
        Task<List<AssistantMessage>> GetByConversationIdAsync(int conversationId);

        // 4. Add new message
        Task AddAsync(AssistantMessage message);
    }
}

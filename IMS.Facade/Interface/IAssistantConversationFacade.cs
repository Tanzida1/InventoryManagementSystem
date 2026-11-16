
using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Facade.Interface
{
    public interface IAssistantConversationFacade
    {
        Task<List<AssistantConversation>> GetAllAsync();

        Task<AssistantConversation?> GetByIdAsync(int conversationId);

        Task<List<AssistantConversation>> GetByUserIdAsync(int userId);

        Task AddAsync(AssistantConversation conversation);

        Task UpdateAsync(AssistantConversation conversation);
    }
}


using IMS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Facade.Interface
{
    public interface IAssistantMessageFacade
    {
        Task<List<AssistantMessage>> GetAllAsync();

        Task<AssistantMessage?> GetByIdAsync(int messageId);

        Task<List<AssistantMessage>> GetByConversationIdAsync(int conversationId);

        Task AddAsync(AssistantMessage message);
    }
}

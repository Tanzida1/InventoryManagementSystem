
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class AssistantMessageFacade : IAssistantMessageFacade
    {
        private readonly IAssistantMessageRepository _assistantMessageRepository;

        public AssistantMessageFacade(
            IAssistantMessageRepository assistantMessageRepository)
        {
            _assistantMessageRepository = assistantMessageRepository;
        }

        public async Task<List<AssistantMessage>> GetAllAsync()
        {
            return await _assistantMessageRepository.GetAllAsync();
        }

        public async Task<AssistantMessage?> GetByIdAsync(int messageId)
        {
            return await _assistantMessageRepository.GetByIdAsync(messageId);
        }

        public async Task<List<AssistantMessage>> GetByConversationIdAsync(int conversationId)
        {
            return await _assistantMessageRepository.GetByConversationIdAsync(conversationId);
        }

        public async Task AddAsync(AssistantMessage message)
        {
            ArgumentNullException.ThrowIfNull(message);

            await _assistantMessageRepository.AddAsync(message);
        }
    }
}

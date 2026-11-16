
using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class AssistantConversationFacade : IAssistantConversationFacade
    {
        private readonly IAssistantConversationRepository _assistantConversationRepository;

        public AssistantConversationFacade(
            IAssistantConversationRepository assistantConversationRepository)
        {
            _assistantConversationRepository = assistantConversationRepository;
        }

        public async Task<List<AssistantConversation>> GetAllAsync()
        {
            return await _assistantConversationRepository.GetAllAsync();
        }

        public async Task<AssistantConversation?> GetByIdAsync(int conversationId)
        {
            return await _assistantConversationRepository.GetByIdAsync(conversationId);
        }

        public async Task<List<AssistantConversation>> GetByUserIdAsync(int userId)
        {
            return await _assistantConversationRepository.GetByUserIdAsync(userId);
        }

        public async Task AddAsync(AssistantConversation conversation)
        {
            ArgumentNullException.ThrowIfNull(conversation);

            await _assistantConversationRepository.AddAsync(conversation);
        }

        public async Task UpdateAsync(AssistantConversation conversation)
        {
            ArgumentNullException.ThrowIfNull(conversation);

            await _assistantConversationRepository.UpdateAsync(conversation);
        }
    }
}

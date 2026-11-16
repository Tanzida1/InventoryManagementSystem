
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class AssistantConversationRepository : IAssistantConversationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AssistantConversationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AssistantConversation>> GetAllAsync()
        {
            return await _dbContext.AssistantConversations.ToListAsync();
        }

        public async Task<AssistantConversation?> GetByIdAsync(int id)
        {
            return await _dbContext.AssistantConversations.FindAsync(id);
        }

        public async Task<List<AssistantConversation>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.AssistantConversations
                .Where(conversation => conversation.UserId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(AssistantConversation conversation)
        {
            await _dbContext.AssistantConversations.AddAsync(conversation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(AssistantConversation conversation)
        {
            _dbContext.AssistantConversations.Update(conversation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            AssistantConversation? conversation =
                await _dbContext.AssistantConversations.FindAsync(id);

            if (conversation == null)
            {
                return;
            }

            _dbContext.AssistantConversations.Remove(conversation);
            await _dbContext.SaveChangesAsync();
        }
    }
}

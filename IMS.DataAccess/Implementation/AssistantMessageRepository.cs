
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class AssistantMessageRepository : IAssistantMessageRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AssistantMessageRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AssistantMessage>> GetAllAsync()
        {
            return await _dbContext.AssistantMessages.ToListAsync();
        }

        public async Task<AssistantMessage?> GetByIdAsync(int id)
        {
            return await _dbContext.AssistantMessages.FindAsync(id);
        }

        public async Task<List<AssistantMessage>> GetByConversationIdAsync(int conversationId)
        {
            return await _dbContext.AssistantMessages
                .Where(message => message.ConversationId == conversationId)
                .ToListAsync();
        }

        public async Task AddAsync(AssistantMessage message)
        {
            await _dbContext.AssistantMessages.AddAsync(message);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(AssistantMessage message)
        {
            _dbContext.AssistantMessages.Update(message);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            AssistantMessage? message =
                await _dbContext.AssistantMessages.FindAsync(id);

            if (message == null)
            {
                return;
            }

            _dbContext.AssistantMessages.Remove(message);
            await _dbContext.SaveChangesAsync();
        }
    }
}

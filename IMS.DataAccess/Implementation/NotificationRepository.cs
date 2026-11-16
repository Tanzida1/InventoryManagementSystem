
using IMS.DataAccess.Interface;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccess.Implementation
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public NotificationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all notifications
        public async Task<List<Notification>> GetAllAsync()
        {
            return await _dbContext.Notifications
                .OrderByDescending(notification => notification.NotificationId)
                .ToListAsync();
        }

        // 2. Get notification by ID
        public async Task<Notification?> GetByIdAsync(int notificationId)
        {
            return await _dbContext.Notifications
                .FindAsync(notificationId);
        }

        // 3. Get notifications by user
        public async Task<List<Notification>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.Notifications
                .Where(notification => notification.UserId == userId)
                .ToListAsync();
        }

        // 4. Get unread notifications by user
        public async Task<List<Notification>> GetUnreadByUserIdAsync(int userId)
        {
            return await _dbContext.Notifications
                .Where(notification =>
                    notification.UserId == userId &&
                    !notification.IsRead)
                .ToListAsync();
        }

        // 5. Add notification
        public async Task AddAsync(Notification notification)
        {
            await _dbContext.Notifications.AddAsync(notification);
            await _dbContext.SaveChangesAsync();
        }

        // 6. Update notification
        public async Task UpdateAsync(Notification notification)
        {
            _dbContext.Notifications.Update(notification);
            await _dbContext.SaveChangesAsync();
        }

        // 7. Delete notification
        public async Task DeleteAsync(int notificationId)
        {
            Notification? notification =
                await _dbContext.Notifications.FindAsync(notificationId);

            if (notification == null)
            {
                return;
            }

            _dbContext.Notifications.Remove(notification);
            await _dbContext.SaveChangesAsync();
        }
    }
}

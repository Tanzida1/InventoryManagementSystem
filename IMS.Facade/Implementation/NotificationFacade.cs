using IMS.DataAccess.Interface;
using IMS.Entities;
using IMS.Facade.Interface;

namespace IMS.Facade.Implementation
{
    public class NotificationFacade : INotificationFacade
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationFacade(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<List<Notification>> GetAllAsync()
        {
            return await _notificationRepository.GetAllAsync();
        }

        public async Task<Notification?> GetByIdAsync(int notificationId)
        {
            return await _notificationRepository.GetByIdAsync(notificationId);
        }

        public async Task<List<Notification>> GetByUserIdAsync(int userId)
        {
            return await _notificationRepository.GetByUserIdAsync(userId);
        }

        public async Task<List<Notification>> GetUnreadByUserIdAsync(int userId)
        {
            return await _notificationRepository.GetUnreadByUserIdAsync(userId);
        }

        public async Task AddAsync(Notification notification)
        {
            ArgumentNullException.ThrowIfNull(notification);
            await _notificationRepository.AddAsync(notification);
        }

        public async Task UpdateAsync(Notification notification)
        {
            ArgumentNullException.ThrowIfNull(notification);
            await _notificationRepository.UpdateAsync(notification);
        }

        public async Task DeleteAsync(int notificationId)
        {
            await _notificationRepository.DeleteAsync(notificationId);
        }
    }
}
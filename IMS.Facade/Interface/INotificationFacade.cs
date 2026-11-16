using IMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Facade.Interface
{
    public  interface INotificationFacade
    {
        // 1. Get all notifications
        Task<List<Notification>> GetAllAsync();

        // 2. Get notification by ID
        Task<Notification?> GetByIdAsync(int notificationId);

        // 3. Get notifications by user
        Task<List<Notification>> GetByUserIdAsync(int userId);

        // 4. Get unread notifications by user
        Task<List<Notification>> GetUnreadByUserIdAsync(int userId);

        // 5. Add notification
        Task AddAsync(Notification notification);

        // 6. Update notification (e.g. mark as read)
        Task UpdateAsync(Notification notification);

        // 7. Delete notification
        Task DeleteAsync(int notificationId);
    }
}

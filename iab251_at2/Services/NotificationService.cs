using System.Collections.Generic;
using System.Linq;

namespace iab251_at2.Services
{
    public class NotificationService
    {
        private static readonly List<Notification> notifications = new List<Notification>();

        // Method to add a notification with quotation details
        public static void AddNotification(string quotationNumber, string message)
        {
            notifications.Add(new Notification
            {
                QuotationNumber = quotationNumber,
                Message = message,
                IsRead = false
            });
        }

        // Method to get unread notifications
        public static List<Notification> GetUnreadNotifications()
        {
            return notifications.Where(n => !n.IsRead).ToList();
        }

        // Method to mark all notifications as read
        public static void MarkNotificationsAsRead()
        {
            foreach (var notification in notifications)
            {
                notification.IsRead = true;
            }
        }

        // Method to get all notifications (for testing)
        public static List<Notification> GetAllNotifications()
        {
            return notifications;
        }
    }

    public class Notification
    {
        public string QuotationNumber { get; set; }  // Added QuotationNumber to identify specific notifications
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}

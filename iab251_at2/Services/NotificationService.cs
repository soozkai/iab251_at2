using System.Collections.Generic;
using System.Linq;

namespace iab251_at2.Services
{
    /// <summary>
    /// Provides methods for managing notifications related to quotations.
    /// </summary>
    public class NotificationService
    {
        // A static list to store notifications
        private static readonly List<Notification> notifications = new List<Notification>();

        /// <summary>
        /// Adds a notification with quotation details.
        /// </summary>
        /// <param name="quotationNumber">The number of the quotation associated with the notification.</param>
        /// <param name="message">The message to be sent with the notification.</param>
        public static void AddNotification(string quotationNumber, string message)
        {
            notifications.Add(new Notification
            {
                QuotationNumber = quotationNumber,
                Message = message,
                IsRead = false
            });
        }

        /// <summary>
        /// Retrieves all unread notifications.
        /// </summary>
        /// <returns>A list of unread notifications.</returns>
        public static List<Notification> GetUnreadNotifications()
        {
            return notifications.Where(n => !n.IsRead).ToList();
        }

        /// <summary>
        /// Marks all notifications as read.
        /// </summary>
        public static void MarkNotificationsAsRead()
        {
            foreach (var notification in notifications)
            {
                notification.IsRead = true;
            }
        }

        /// <summary>
        /// Gets all notifications, including read and unread notifications.
        /// This method is primarily for testing purposes.
        /// </summary>
        /// <returns>A list of all notifications.</returns>
        public static List<Notification> GetAllNotifications()
        {
            return notifications;
        }
    }

    /// <summary>
    /// Represents a notification related to a quotation.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Gets or sets the quotation number associated with the notification.
        /// </summary>
        public string QuotationNumber { get; set; }  // Added QuotationNumber to identify specific notifications

        /// <summary>
        /// Gets or sets the message of the notification.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the notification has been read.
        /// </summary>
        public bool IsRead { get; set; }
    }
}

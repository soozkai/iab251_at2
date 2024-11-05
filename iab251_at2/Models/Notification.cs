using System;

namespace iab251_at2.Models
{
    /// <summary>
    /// Represents a notification related to a quotation.
    /// This class holds the details of the notification including 
    /// the quotation number, message content, timestamp, and read status.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Gets or sets the unique identifier for the notification.
        /// A new identifier is generated using a GUID when a notification is created.
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Gets or sets the quotation number associated with this notification.
        /// </summary>
        public string QuotationNumber { get; set; }

        /// <summary>
        /// Gets or sets the message content of the notification.
        /// This provides the user with information regarding the status or action related to a quotation.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the notification was created.
        /// The default value is set to the current date and time when the notification is instantiated.
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets a value indicating whether the notification has been read.
        /// The default value is false, indicating that the notification is unread.
        /// </summary>
        public bool IsRead { get; set; } = false;
    }
}

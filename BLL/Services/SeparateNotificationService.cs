using BLL.Interfaces;
using BLL.Models;
using Shared;

namespace BLL.Services
{
    public class SeparateNotificationService : ISeparateNotification
    {
        public Notification SeparateNotifications(Notification notification) => notification.Type switch
        {
            NotificationType.email => new EmailNotification(notification),
            NotificationType.sms => new SMSNotification(notification),
            NotificationType.pdf => new PdfNotification(notification),
            _ => throw new ArgumentException(),
        };
    }
}

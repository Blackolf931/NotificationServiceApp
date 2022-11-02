namespace BLL.Models
{
    public class SMSNotification: Notification
    {
        public SMSNotification(Notification notification)
        {
            Name = notification.Name;
            Message = notification.Message;
            Type = Shared.NotificationType.sms;
        }
    }
}

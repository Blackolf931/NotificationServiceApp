namespace BLL.Models
{
    public class EmailNotification : Notification
    {
        public EmailNotification(Notification notification)
        {
            Name = notification.Name;
            Message = notification.Message;
            Type = Shared.NotificationType.email;
        }
    }
}

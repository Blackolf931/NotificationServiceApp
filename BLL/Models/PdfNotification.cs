namespace BLL.Models
{
    public class PdfNotification : Notification
    {
        public PdfNotification(Notification notification)
        {
            Name = notification.Name;
            Message = notification.Message;
            Type = Shared.NotificationType.pdf;
        }
    }
}

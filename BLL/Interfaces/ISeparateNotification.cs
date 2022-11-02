using BLL.Models;

namespace BLL.Interfaces
{
    public interface ISeparateNotification
    {
        Notification SeparateNotifications(Notification notification);
    }
}

using BLL.Models;
using System.Text;

namespace BLL.Interfaces
{
    public interface IGenerateNotification
    {
        StringBuilder GenerateNotifications(Notification notification);
    }
}

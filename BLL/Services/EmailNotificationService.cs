using BLL.Interfaces;
using BLL.Models;
using Shared;

namespace BLL.Services
{
    public class EmailNotificationService : GenericService<EmailNotification>
    {
        private readonly IGenerateNotification _generateNotification;
        public EmailNotificationService(IGenerateNotification generateNotification)
        {
            _generateNotification = generateNotification;
        }
        public override async Task SendNotification(EmailNotification model)
        {
            var notification = _generateNotification.GenerateNotifications(model);

            await File.WriteAllTextAsync($"{Directory.GetCurrentDirectory()}\\{Consts.emailNotification}\\{model.Name}.json", notification.ToString());
        }
    }
}

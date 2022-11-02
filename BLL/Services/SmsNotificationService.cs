using BLL.Interfaces;
using BLL.Models;
using Shared;

namespace BLL.Services
{
    public class SmsNotificationService : GenericService<SMSNotification>
    {
        private readonly IGenerateNotification _generateNotification;
        public SmsNotificationService(IGenerateNotification generateNotification)
        {
            _generateNotification = generateNotification;
        }
        public override async Task SendNotification(SMSNotification model)
        {
            var notification = _generateNotification.GenerateNotifications(model);

            await File.WriteAllTextAsync($"{Consts.smsNotification}\\{model.Name}.json", notification.ToString());
        }
    }
}

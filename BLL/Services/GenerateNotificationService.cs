using BLL.Interfaces;
using BLL.Models;
using Microsoft.Extensions.Logging;
using Shared;
using System.Text;

namespace BLL.Services
{
    public class GenerateNotificationService : IGenerateNotification
    {
        private readonly ILogger<GenerateNotificationService> _logger;

        public GenerateNotificationService(ILogger<GenerateNotificationService> logger)
        {
            _logger = logger;
        }

        public StringBuilder GenerateNotifications(Notification notification)
        {
            try
            {
                var templateNotification = GetTemplate();
                templateNotification.Replace($"{Consts.nameTemplate}", notification.Name);
                templateNotification.Replace($"{Consts.messageTemplate}", notification.Message);
                return templateNotification;
            }
            catch (FileNotFoundException ex)
            {
                _logger.LogError(ex.Message);
            }
            return new StringBuilder();
        }

        private StringBuilder GetTemplate() => new(File.ReadAllText(new DirectoryInfo(Consts.templateNotificationPath).ToString()));
    }
}

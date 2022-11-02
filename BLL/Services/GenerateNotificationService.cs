using BLL.Interfaces;
using BLL.Models;
using Shared;
using System.Text;

namespace BLL.Services
{
    public class GenerateNotificationService : IGenerateNotification
    {
        public StringBuilder GenerateNotifications(Notification notification)
        {
            try
            {
                var templateNotification = GetTemplate();
                templateNotification.Replace("[name]", notification.Name);
                templateNotification.Replace("[message]", notification.Message);
                return templateNotification;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw new FileNotFoundException();
            }
        }

        private StringBuilder GetTemplate() => new(File.ReadAllText(new DirectoryInfo($"{Directory.GetCurrentDirectory()}\\{Consts.templatePath}").ToString()));
    }
}

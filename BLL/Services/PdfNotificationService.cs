using BLL.Interfaces;
using BLL.Models;
using Shared;

namespace BLL.Services
{
    public class PdfNotificationService : GenericService<PdfNotification>
    {
        private readonly IGenerateNotification _generateNotification;
        public PdfNotificationService(IGenerateNotification generateNotification)
        {
            _generateNotification = generateNotification;
        }
        public override async Task SendNotification(PdfNotification model)
        {
            var notification = _generateNotification.GenerateNotifications(model);

            await File.WriteAllTextAsync($"{Directory.GetCurrentDirectory()}\\{Consts.pdfNotification}\\{model.Name}.pdf", notification.ToString());
        }
    }
}

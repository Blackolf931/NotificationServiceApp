using BLL.Interfaces;
using BLL.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared;
using System.Text.Json;

namespace BackgroundService
{
    public class FilesCollector : IFilesCollector
    {
        private readonly IServiceProvider _provider;
        private readonly ISeparateNotification _separateNotification;
        private readonly IGenericService<EmailNotification> _emailNotificatioNService;
        private readonly IGenericService<PdfNotification> _pdfNotificationService;
        private readonly IGenericService<SMSNotification> _smsNotificationService;
        private readonly ILogger<FilesCollector> _logger;

        public FilesCollector(IServiceProvider provider)
        {
            _provider = provider;
            using var scope = _provider.CreateScope();
            _separateNotification = scope.ServiceProvider.GetRequiredService<ISeparateNotification>();
            _emailNotificatioNService = scope.ServiceProvider.GetRequiredService<IGenericService<EmailNotification>>();
            _pdfNotificationService = scope.ServiceProvider.GetRequiredService<IGenericService<PdfNotification>>();
            _smsNotificationService = scope.ServiceProvider.GetRequiredService<IGenericService<SMSNotification>>();
            _logger = scope.ServiceProvider.GetRequiredService<ILogger<FilesCollector>>();
        }

        public async Task<FileInfo[]> GetFiles()
        {
            try
            {
                var directory = new DirectoryInfo($"{Directory.GetCurrentDirectory()}\\{Consts.directoryPath}");
                return directory.GetFiles("*.json");
            }
            catch (DirectoryNotFoundException ex)
            {
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return new FileInfo[] {};
        }

        public async Task StartCollector()
        {
            var files = await GetFiles();
            var notifications = await ReadFiles(files);
            foreach (var el in notifications)
            {
                switch (el.Type)
                {
                    case NotificationType.pdf:
                        await _pdfNotificationService.SendNotification((PdfNotification)el);
                        break;
                    case NotificationType.email:
                        await _emailNotificatioNService.SendNotification((EmailNotification)el);
                        break;
                    case NotificationType.sms:
                        await _smsNotificationService.SendNotification((SMSNotification)el);
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            DeleteFiles(files);
        }

        private async Task<IEnumerable<Notification>> ReadFiles(IEnumerable<FileInfo> files)
        {
            var notifications = new List<Notification>();

            foreach (var el in files)
            {
                try
                {
                    var reader = new FileStream(el.FullName, FileMode.Open);
                    var fileInformation = await JsonSerializer.DeserializeAsync<Notification>(reader);
                    reader.Dispose();
                    notifications.Add(_separateNotification.SeparateNotifications(fileInformation));
                }
                catch (FileNotFoundException ex)
                {
                    _logger?.LogError(ex.Message);
                }
                catch (NullReferenceException ex)
                {
                    _logger?.LogError(ex.Message);
                }
            }
            return notifications;
        }
        private void DeleteFiles(FileInfo[] files)
        {
            files.ToList().ForEach(x => x.Delete());
        }
    }
}

namespace Shared
{
    public static class Consts
    {
        public static string notificationsPath = $@"{directoryPath}\\Notifications";
        public static string templateNotificationPath = $@"{directoryPath}\\Template\Template.json";
        public static string emailNotification = $@"{directoryPath}\\SendNotifications\Email";
        public static string pdfNotification = $@"{directoryPath}\\SendNotifications\Pdf";
        public static string smsNotification = $@"{directoryPath}\\SendNotifications\Sms";
        public static string directoryPath = $"{Directory.GetCurrentDirectory()}";
        public const string nameTemplate = "[name]";
        public const string messageTemplate = "[message]";
    }
}
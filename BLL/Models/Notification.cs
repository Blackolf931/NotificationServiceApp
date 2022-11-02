using Shared;
using System.Text.Json.Serialization;

namespace BLL.Models
{
    public class Notification
    {
        public string Name { get; set; }
        public string Message { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public NotificationType Type { get; set; }
    }
}

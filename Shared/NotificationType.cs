using System.Text.Json.Serialization;

namespace Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum NotificationType
    {
        email,
        pdf,
        sms
    }
}

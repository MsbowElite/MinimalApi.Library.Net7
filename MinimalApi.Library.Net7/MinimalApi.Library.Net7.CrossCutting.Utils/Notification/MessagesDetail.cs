using System.Text.Json;
using System.Text.Json.Serialization;

namespace MinimalApi.Library.Net7.CrossCutting.Utils.Notification
{
    public class MessagesDetail
    {
        [JsonPropertyName("field")]
        public string? Field { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}

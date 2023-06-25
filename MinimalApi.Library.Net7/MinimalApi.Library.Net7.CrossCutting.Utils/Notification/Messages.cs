using MinimalApi.Library.Net7.CrossCutting.Utils.Helpers;
using MinimalApi.Library.Net7.CrossCutting.Utils.Notification.Enums;
using System.Text.Json.Serialization;

namespace MinimalApi.Library.Net7.CrossCutting.Utils.Notification
{
    public class Messages
    {
        public Messages(ErrorCodes code, MessagesDetail field)
        {
            Code = code;
            AddField(field);
        }

        public Messages(ErrorCodes code, List<MessagesDetail> field)
        {
            Code = code;
            Fields = field;
        }

        public Messages(ErrorCodes code)
        {
            Code = code;
        }

        [JsonPropertyName("code")]
        public ErrorCodes Code { get; }
        [JsonPropertyName("message")]
        public string Message => Code.GetDescription();
        [JsonPropertyName("fields")]
        public List<MessagesDetail> Fields { get; private set; } = new List<MessagesDetail>();

        public void AddField(MessagesDetail detail)
        {
            if (detail is object)
                Fields.Add(detail);
        }
    }
}

using MinimalApi.Library.Net7.CrossCutting.Utils.Notification.Enums;
using MinimalApi.Library.Net7.CrossCutting.Utils.Notification.Interfaces;
using System.Text.Json.Serialization;

namespace MinimalApi.Library.Net7.CrossCutting.Utils.Notification
{
    public class FailedOperation : IOperation
    {
        public FailedOperation() { }

        public FailedOperation(ErrorCodes code, MessagesDetail detail)
        {
            Messages = new Messages(code, detail);
        }

        public FailedOperation(ErrorCodes code, List<MessagesDetail> detail)
        {
            Messages = new Messages(code, detail);
        }

        public FailedOperation(ErrorCodes code)
        {
            Messages = new Messages(code);
        }
        public FailedOperation(Messages messages)
        {
            Messages = messages;
        }

        [JsonPropertyName("messages")]
        public Messages Messages { get; private set; }

        public IOperation<T> GetTyped<T>()
        {
            return new FailedOperation<T>(Messages);
        }
    }

    public class FailedOperation<T> : FailedOperation, IOperation<T>
    {
        public FailedOperation(ErrorCodes code) : base(code)
        {
        }

        public FailedOperation(Messages messages) : base(messages)
        {
        }

        public FailedOperation(ErrorCodes code, MessagesDetail detail) : base(code, detail)
        {
        }

        public FailedOperation(ErrorCodes code, List<MessagesDetail> detail) : base(code, detail)
        {
        }
    }
}

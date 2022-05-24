using MinimalApi.Library.Net7.CrossCutting.Utils.Notification.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MinimalApi.Library.Net7.CrossCutting.Utils.Notification
{
    public class SuccessfulOperation : IOperation
    {
        public SuccessfulOperation() { }
    }

    public class SuccessfulOperation<T> : SuccessfulOperation, IOperation<T>
    {
        public SuccessfulOperation(T data) : base()
        {
            Data = data;
        }

        [JsonPropertyName("data")]
        public T Data { get; private set; }

        public static implicit operator SuccessfulOperation<T>(T data)
        {
            return new SuccessfulOperation<T>(data);
        }
    }
}

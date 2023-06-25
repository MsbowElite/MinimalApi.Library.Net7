using MinimalApi.Library.Net7.CrossCutting.Utils.Notification.Enums;
using MinimalApi.Library.Net7.CrossCutting.Utils.Notification.Interfaces;

namespace MinimalApi.Library.Net7.CrossCutting.Utils.Notification
{
    public static class Result
    {
        public static IOperation CreateSuccess()
        {
            return new SuccessfulOperation();
        }

        public static IOperation<T> CreateSuccess<T>(T value)
        {
            return new SuccessfulOperation<T>(value);
        }

        public static IOperation<T> CreateFailure<T>(ErrorCodes code, MessagesDetail field)
        {
            return new FailedOperation<T>(code, field);
        }

        public static IOperation<T> CreateFailure<T>(ErrorCodes code, List<MessagesDetail> field)
        {
            return new FailedOperation<T>(code, field);
        }

        public static IOperation CreateFailure(ErrorCodes code, MessagesDetail field)
        {
            return new FailedOperation(code, field);
        }

        public static IOperation CreateFailure(ErrorCodes code, List<MessagesDetail> field)
        {
            return new FailedOperation(code, field);
        }

        public static IOperation CreateFailure(ErrorCodes code)
        {
            return new FailedOperation(code);
        }

        public static IOperation<T> CreateFailure<T>(ErrorCodes code)
        {
            return new FailedOperation<T>(code);
        }

        public static IOperation<T> CreateFailure<T>(Messages messages)
        {
            return new FailedOperation<T>(messages);
        }
    }
}

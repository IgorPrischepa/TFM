using System.Runtime.Serialization;

namespace tfm.api.exceptions
{
    public class MissingStyleException : Exception
    {
        public MissingStyleException()
        {
        }

        public MissingStyleException(string? message) : base(message)
        {
        }

        public MissingStyleException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MissingStyleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

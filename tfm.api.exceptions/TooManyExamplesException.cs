using System.Runtime.Serialization;

namespace tfm.api.exceptions
{
    public class TooManyExamplesException : Exception
    {
        public TooManyExamplesException()
        {
        }

        public TooManyExamplesException(string? message) : base(message)
        {
        }

        public TooManyExamplesException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TooManyExamplesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
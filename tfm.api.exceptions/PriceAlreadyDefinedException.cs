using System.Runtime.Serialization;

namespace tfm.api.exceptions
{
    public class PriceAlreadyDefinedException : Exception
    {
        public PriceAlreadyDefinedException()
        {
        }

        public PriceAlreadyDefinedException(string? message) : base(message)
        {
        }

        public PriceAlreadyDefinedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PriceAlreadyDefinedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
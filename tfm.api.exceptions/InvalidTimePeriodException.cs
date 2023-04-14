using System.Runtime.Serialization;

namespace tfm.api.exceptions;

public class InvalidTimePeriodException : Exception
{
    protected InvalidTimePeriodException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public InvalidTimePeriodException(string? message) : base(message)
    {
    }

    public InvalidTimePeriodException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
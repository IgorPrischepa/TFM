using System.Runtime.Serialization;

namespace tfm.api.exceptions;

public class DateTimeOverlappedException : Exception
{
    protected DateTimeOverlappedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public DateTimeOverlappedException(string? message) : base(message)
    {
    }

    public DateTimeOverlappedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
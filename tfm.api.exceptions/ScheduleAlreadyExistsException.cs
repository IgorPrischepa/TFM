using System.Runtime.Serialization;

namespace tfm.api.exceptions;

public class ScheduleAlreadyExistsException : Exception
{
    protected ScheduleAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public ScheduleAlreadyExistsException(string? message) : base(message)
    {
    }

    public ScheduleAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
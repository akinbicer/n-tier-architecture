using log4net.Core;

namespace Core.CrossCuttingConcerns.Logging.Log4Net;

[Serializable]
public class SerializableLogEvent
{
    public object Message => _loggingEvent.MessageObject;
    private readonly LoggingEvent _loggingEvent;

    public SerializableLogEvent(LoggingEvent loggingEvent)
    {
        _loggingEvent = loggingEvent;
    }
}
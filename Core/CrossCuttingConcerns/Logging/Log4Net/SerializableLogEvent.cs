using log4net.Core;

namespace Core.CrossCuttingConcerns.Logging.Log4Net;

[Serializable]
public class SerializableLogEvent
{
    private readonly LoggingEvent _loggingEvent;
    public object Message => _loggingEvent.MessageObject;

    public SerializableLogEvent(LoggingEvent loggingEvent)
    {
        _loggingEvent = loggingEvent;
    }
}
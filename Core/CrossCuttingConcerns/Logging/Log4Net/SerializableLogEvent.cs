
using log4net.Core;

namespace Core.CrossCuttingConcerns.Autofac.Logging.Log4Net
{
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        public object Message => this._loggingEvent.MessageObject;
    }
}


using Core.Aspects.Autofac.Logging;

namespace Core.CrossCuttingConcerns.Autofac.Logging
{
    public class LogDetailWithException : LogDetail
    {
        public string ExceptionMessage { get; set; }
    }
}

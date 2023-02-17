using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;

namespace Core.Aspects.Autofac.Exception;

public class ExceptionLogAspect : MethodInterception
{
    private readonly LoggerServiceBase _loggerServiceBase;

    public ExceptionLogAspect(Type loggerService)
    {
        if (loggerService.BaseType != typeof(LoggerServiceBase)) throw new System.Exception(AspectMessages.WrongLoggerType);

        _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
    }

    protected override void OnException(IInvocation invocation, System.Exception e)
    {
        var logDetailWithException = GetLogDetail(invocation);
        logDetailWithException.ExceptionMessage = e.Message;
        _loggerServiceBase.Error(logDetailWithException);
    }

    private LogDetailWithException GetLogDetail(IInvocation invocation)
    {
        List<LogParameter> logParameters = new();

        for (var i = 0; i < invocation.Arguments.Length; i++)
            logParameters.Add(new LogParameter
            {
                Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                Value = invocation.Arguments[i],
                Type = invocation.Arguments[i].GetType().Name
            });

        LogDetailWithException logDetailWithException = new()
        {
            MethodName = invocation.Method.Name,
            LogParameters = logParameters
        };

        return logDetailWithException;
    }
}
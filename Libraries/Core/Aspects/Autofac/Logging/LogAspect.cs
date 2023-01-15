using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;

namespace Core.Aspects.Autofac.Logging;

public class LogAspect : MethodInterception
{
    private readonly LoggerServiceBase _loggerServiceBase;

    public LogAspect(Type loggerService)
    {
        if (loggerService.BaseType != typeof(LoggerServiceBase)) throw new System.Exception(AspectMessages.WrongLoggerType);

        _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
    }

    protected override void OnBefore(IInvocation invocation)
    {
        _loggerServiceBase.Info(GetLogDetail(invocation));
    }

    private LogDetail GetLogDetail(IInvocation invocation)
    {
        List<LogParameter> logParameters = new();
        for (var i = 0; i < invocation.Arguments.Length; i++)
            logParameters.Add(new LogParameter
            {
                Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                Value = invocation.Arguments[i],
                Type = invocation.Arguments[i].GetType().Name
            });

        LogDetail logDetail = new()
        {
            MethodName = invocation.Method.Name,
            LogParameters = logParameters
        };

        return logDetail;
    }
}
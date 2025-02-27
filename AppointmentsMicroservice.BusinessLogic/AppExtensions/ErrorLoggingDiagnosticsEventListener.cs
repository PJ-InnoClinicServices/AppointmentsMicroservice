using HotChocolate.Execution;
using HotChocolate.Execution.Instrumentation;
using HotChocolate.Execution.Processing;
using HotChocolate.Resolvers;
using Microsoft.Extensions.Logging;

namespace BusinessLogicLayer.AppExtensions;

public class ErrorLoggingDiagnosticsEventListener(ILogger<ErrorLoggingDiagnosticsEventListener> log)
    : ExecutionDiagnosticEventListener
{
    public override void ResolverError(
        IMiddlewareContext context,
        IError error)
    {
        log.LogError(error.Exception, error.Message);
    }

    public override void TaskError(
        IExecutionTask task,
        IError error)
    {
        log.LogError(error.Exception, error.Message);
    }

    public override void RequestError(
        IRequestContext context,
        Exception exception)
    {
        log.LogError(exception, "RequestError");
    }

    public override void SubscriptionEventError(
        SubscriptionEventContext context,
        Exception exception)
    {
        log.LogError(exception, "SubscriptionEventError");
    }

    public override void SubscriptionTransportError(
        ISubscription subscription,
        Exception exception)
    {
        log.LogError(exception, "SubscriptionTransportError");
    }
}
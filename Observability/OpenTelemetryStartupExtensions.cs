using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Observability;

public static class OpenTelemetryStartupExtensions
{
    /// <summary>
    /// OpenTelemetry tracing extension method to add to 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="serviceName">The name of the microservice</param>
    /// <returns></returns>
    public static OpenTelemetryBuilder AddOpenTelementryTracing(this IServiceCollection services, string serviceName)
    {
        return services.AddOpenTelementryTracing(serviceName)
            .ConfigureResource(r => 
                r.AddService(serviceName))
            .WithTracing(builder =>
            {
                builder
                    .AddConsoleExporter() // Export to the console
                    .AddAspNetCoreInstrumentation();
            }); //Configuration of the trace provider
    }
}
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
    /// /// <param name="customTracing">Allow servvices to use SQL instrumentation/param>
    /// <returns></returns>
    public static OpenTelemetryBuilder AddOpenTelemetryTracing(this IServiceCollection services, string serviceName, Action<TracerProviderBuilder>? customTracing = null)
    {
        return services.AddOpenTelemetry()
            .ConfigureResource(r => 
                r.AddService(serviceName))
            .WithTracing(builder =>
            {
                builder
                    .AddConsoleExporter() // Export to the console
                    .AddAspNetCoreInstrumentation();

                customTracing?.Invoke(builder);
            }); //Configuration of the trace provider
    }

    //For service that needs the SQL Instrumentation
    public static TracerProviderBuilder WithSqlInstrumentation(this TracerProviderBuilder builder) =>
        builder.AddSqlClientInstrumentation();
}
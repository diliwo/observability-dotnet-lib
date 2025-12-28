using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeka.Extensions.Observability.RabbitMq
{
    /// <summary>
    /// Telemetry for RabbitMQ Event Bus.
    /// </summary>
    public class RabbitMqTelemetry
    {
        public const string ActivitySourceName = "RabbitMqEventBus";
        /// <summary>
        /// Will be use for custom spans.
        /// </summary>
        public ActivitySource ActivitySource { get; } = new ActivitySource(ActivitySourceName);
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeka.Extensions.Observability.RabbitMq
{
    /// <summary>
    /// OpenTelemetry properties semantic conventions.
    /// </summary>
    public class OpenTelemetryMessagingConventions
    {
        public const string PublishOperation = "publish";
        public const string System = "messaging.system";
        public const string OperationName = "messaging.operation.name";
        public const string DestinationName = "messaging.destination.name";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.Exceptions
{
    public class PrometheusException: ApplicationException
    {
        public PrometheusException() : base()
        {

        }

        public PrometheusException(string message) : base(message)
        {

        }

        public PrometheusException(string message, Exception innerException) : base(message, innerException)
        {

        }

    }
}

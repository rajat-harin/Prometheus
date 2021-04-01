using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.Entities
{
    public class HomeworkPlan
    {
        public int StudentID { get; set; }
        public int HomeworkID { get; set; }
        public int PriorityLevel { get; set; }
        public bool isCompleted { get; set; }
    }
}

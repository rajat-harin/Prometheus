using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.Entities
{
    public class Homework
    {
        public int HomeworkID { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime ReqTime { get; set; }
        public string LongDescription { get; set; }
        public Homework()
        {
            HomeworkID = 0;
            Description = String.Empty;
            Deadline = DateTime.Now;
            ReqTime = DateTime.Now;
            LongDescription = String.Empty;
        }
        public Homework(int id, string description, DateTime deadline, DateTime reqTime, string longDescription)
        {
            HomeworkID = id;
            Description = description;
            Deadline = deadline;
            ReqTime = reqTime;
            LongDescription = longDescription;
        }
    }
}

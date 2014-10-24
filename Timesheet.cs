using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planbox.Net
{
    public class TimesheetResult
    {
        public TimesheetCollection content { get; set; }
        public string code { get; set; }
        public string redirect { get; set; }
        public int time { get; set; }
    }

    public class TimesheetCollection
    {
        public List<Timesheet> timesheet { get; set; }
        public List<Project> projects { get; set; }
        public List<Story> stories { get; set; }
        public List<PlanboxTask> tasks { get; set; }
    }

    public class Timesheet
    {
        public int task_id { get; set; }
        public string date { get; set; }
        public int product_id { get; set; }
        public int resource_id { get; set; }
        public int role_id { get; set; }
        public string created_on { get; set; }
        public int estimate { get; set; }
        public double logged { get; set; }
        public string status { get; set; }
        public int story_id { get; set; }
        public int project_id { get; set; }
    }
}

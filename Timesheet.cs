using System.Collections.Generic;
using System.Linq;

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
        public List<TimesheetRecord> timesheet { get; set; }
        public List<Project> projects { get; set; }
        public List<Story> stories { get; set; }
        public List<PlanboxTask> tasks { get; set; }

        public IEnumerable<Timesheet> AsTimesheets(IEnumerable<Resource> resources)
        {
            return from ts in this.timesheet
                   let s = this.stories.FirstOrDefault(s => s.id == ts.story_id)
                   let p = this.projects.FirstOrDefault(p => p.id == ts.project_id)
                   let t = this.tasks.FirstOrDefault(t => t.id == ts.task_id)
                   let r = resources.FirstOrDefault(r => r.resource_id == ts.resource_id) ?? new Resource() { resource_id = ts.resource_id, name = ts.resource_id.ToString() }
                   select new Timesheet()
                              {
                                  story = s, 
                                  task = t, 
                                  project = p, 
                                  resource = r, 
                                  date = ts.date, 
                                  logged = ts.logged
                              };
        }
    }

    public class TimesheetRecord
    {
        public int task_id { get; set; }
        public string date { get; set; }
        public int product_id { get; set; }
        public int resource_id { get; set; }
        public int role_id { get; set; }
        public string created_on { get; set; }
        public double estimate { get; set; }
        public double logged { get; set; }
        public string status { get; set; }
        public int story_id { get; set; }
        public int project_id { get; set; }
    }

    public class Timesheet
    {
        public PlanboxTask task { get; set; }
        public Resource resource { get; set; }
        public Story story { get; set; }
        public Project project { get; set; }
        public double logged { get; set; }
        public string date { get; set; }
    }
}

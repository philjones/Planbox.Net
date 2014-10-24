using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planbox.Net
{
    public class ResourcesResult
    {
        public List<Resource> content { get; set; }
        public string code { get; set; }
        public string redirect { get; set; }
        public int time { get; set; }
    }

    public class ResourceResult
    {
        public Resource content { get; set; }
        public string code { get; set; }
        public string redirect { get; set; }
        public int time { get; set; }
    }

    public class Resource
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int referer_id { get; set; }
        public string timezone { get; set; }
        public int time_available_per_week { get; set; }
        public string image { get; set; }
        public object canceled_on { get; set; }
        public object password { get; set; }
        public int activity { get; set; }
        public List<string> story_columns { get; set; }
        public string show_chart { get; set; }
        public int show_welcome { get; set; }
        public int show_sorting { get; set; }
        public int show_filtering { get; set; }
        public int show_completed { get; set; }
        public int show_completed_tasks { get; set; }
    }
}

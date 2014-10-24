using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planbox.Net
{
    public class EventsResult
    {
        public List<Event> content { get; set; }
        public string code { get; set; }
        public string redirect { get; set; }
        public int time { get; set; }
    }

    public class Event
    {
        public int id { get; set; }
        public string @object { get; set; }
        public int object_id { get; set; }
        public string name { get; set; }
        public string product_id { get; set; }
        public string due_on { get; set; }
        public string image { get; set; }
        public string status { get; set; }
        public string comment { get; set; }
        public string type { get; set; }
    }
}

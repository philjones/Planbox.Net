namespace Planbox.Net
{
    public class PlanboxTask
    {
        public int id { get; set; }
        public int story_id { get; set; }
        public int priority { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tags { get; set; }
        public int resource_id { get; set; }
        public int role_id { get; set; }
        public double estimate { get; set; }
        public double duration { get; set; }
        public string status { get; set; }
        public string timer_start { get; set; }
        public int? timer_sum { get; set; }
        public int? cloned_from_task_id { get; set; }
        public int timer_ago { get; set; }
    }

    public class TaskResult
    {
        public PlanboxTask content { get; set; }
        public string code { get; set; }
        public string redirect { get; set; }
        public int time { get; set; }
    }
}

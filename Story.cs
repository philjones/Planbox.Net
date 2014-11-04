namespace Planbox.Net
{
    using System.Collections.Generic;

    public class Story
    {
        public int id { get; set; }
        public int priority { get; set; }
        public string type { get; set; }
        public string tags { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string note { get; set; }
        public int project_id { get; set; }
        public int product_id { get; set; }
        public int iteration_id { get; set; }
        public string timeframe { get; set; }
        public string permission { get; set; }
        public string association { get; set; }
        public string status { get; set; }
        public int importance { get; set; }
        public int carried_over_count { get; set; }
        public List<object> carried_over_story_ids { get; set; }
        public object carried_over_note { get; set; }
        public string created_on { get; set; }
        public object completed_on { get; set; }
        public int creator_id { get; set; }
        public int points { get; set; }
        public int value { get; set; }
        public object due_on { get; set; }
        public string version { get; set; }
        public int blocked { get; set; }
        public object ticket { get; set; }
        public int baseline { get; set; }
        public int baseline_estimate { get; set; }
        public int recurring { get; set; }
        public string source { get; set; }
        public object cloned_from_story_id { get; set; }
        public int? last_story_id { get; set; }
        public List<object> past_tasks { get; set; }
        public List<PlanboxTask> tasks { get; set; }
        public List<object> files { get; set; }
        public List<object> comments { get; set; }
        public List<object> feedback { get; set; }
    }

    public class StoriesResult
    {
        public List<Story> content { get; set; }
        public string code { get; set; }
        public string redirect { get; set; }
        public int time { get; set; }
    }

    public class UpdateStoryStatusResult
    {
        public UpdateStoryStatus content { get; set; } 
        public string code { get; set; }
        public string redirect { get; set; }
        public int time { get; set; }
    }

    public class UpdateStoryStatus
    {
        public Story story { get; set; }
        public int history_id { get; set; }
    }

    public enum UpdateStoryAction
    {
        complete,
        deliver,
        accept,
        reject
    }
}

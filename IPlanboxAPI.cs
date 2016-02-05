namespace Planbox.Net
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPlanboxAPI
    {
        // Login
        void SetAccessToken(string access_token);
        Task<string> Login(string email, string password);
        Task<Resource> GetLoggedIn();

        // Products & Projects
        Task<IEnumerable<Product>> GetProducts();
        Task<bool> GetProjects(string product_id);

        // Stories
        Task<IEnumerable<Story>> GetStories(string product_id, string project_id);
        Task<IEnumerable<Story>> GetStories(string product_id, IEnumerable<string> iteration_ids = null, IEnumerable<string> resource_ids = null);
        Task<IEnumerable<Story>> UpdateStory(string story_id, string name = null, string status = null, string description = null,int? points = null);

        /// <summary>
        /// *EXPERIMENTAL* Update a story status
        /// </summary>
        Task<Story> UpdateStoryStatus(string story_id, UpdateStoryAction action);

        // Tasks
        Task<PlanboxTask> AddTask(string story_id, string name = null, string description = null,
            string tags = null, string resource_id = null, string role_id = null, string estimate = null,
            decimal? duration = null, DateTime? timer_start = null, int? timer_sum_in_seconds = null, string status = null);

        Task<bool> UpdateTask(string task_id, string story_id, string name = null, string description = null,
            string tags = null, string resource_id = null, string role_id = null, string estimate = null,
            decimal? duration = null, DateTime? timer_start = null, int? timer_sum_in_seconds = null, string status = null);

        // Events
        Task<IEnumerable<Event>> GetEvents(string product_id, string start, string end);

        // Resources
        Task<IEnumerable<Resource>> GetContacts(); 
        Task<IEnumerable<Resource>> GetResources(string product_id);

        /// <summary>
        /// *EXPERIMENTAL* returns the timesheet data for the time period between start and end.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        Task<IEnumerable<Timesheet>> GetTimesheet(DateTime start, DateTime end);
    }

    public enum PlanboxStatus
    {
        pending,
        inprogress,
        completed
    };
}

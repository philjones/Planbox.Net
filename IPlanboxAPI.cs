using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Planbox.Net
{
    public interface IPlanboxAPI
    {
        // Login
        Task<string> Login(string email, string password);
        Task<Resource> GetLoggedIn();

        // Products & Projects
        Task<bool> GetProducts();
        Task<bool> GetProjects(string product_id);

        // Stories
        Task<IEnumerable<Story>> GetStories(string product_id, string project_id);
        Task<IEnumerable<Story>> GetStories(string product_id, IEnumerable<string> story_ids);

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

        Task<IEnumerable<Resource>> GetResources(string product_id);

        // Timesheet
        /// <summary>
        /// *EXPERIMENTAL* returns the timesheet data for the time period between start and end.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        Task<TimesheetCollection> GetTimesheet(DateTime start, DateTime end);
    }

    public enum PlanboxStatus
    {
        pending,
        inprogress,
        completed
    };
}

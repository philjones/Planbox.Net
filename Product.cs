using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planbox.Net
{
    public class Product
    {
        public int id { get; set; }
        public int organization_id { get; set; }
        public string name { get; set; }
        public int owner_id { get; set; }
        public string description { get; set; }
        public string timezone { get; set; }
        public string iteration_start { get; set; }
        public int iteration_length { get; set; }
        public string iteration_length_unit { get; set; }
        public string image { get; set; }
        public int show_estimate { get; set; }
        public int show_duration { get; set; }
        public int show_points { get; set; }
        public int show_value { get; set; }
        public string value_unit { get; set; }
        public int show_importance { get; set; }
        public int show_role { get; set; }
        public int show_tags { get; set; }
        public int show_task_description { get; set; }
        public int show_task_tags { get; set; }
        public int template { get; set; }
        public int locked { get; set; }
        public string created_on { get; set; }
        public int creator_id { get; set; }
        public string permission { get; set; }
        public List<int> resource_ids { get; set; }
        public List<int> project_ids { get; set; }
        public EmailNotifications email_notifications { get; set; }
        public int chat { get; set; }
        public int feedback { get; set; }
        public int zendesk { get; set; }
        public string zendesk_url { get; set; }
        public bool github_enabled { get; set; }
        public int snapengage { get; set; }
        public int third_party_api { get; set; }
        public int baseline { get; set; }
        public string token { get; set; }
        public string pr_token { get; set; }
        public List<Iteration> iterations { get; set; }
        public int capacity { get; set; }
        public Defaults defaults { get; set; }
        public bool is_tutorial { get; set; }
        public int admins_count { get; set; }
        public bool uservoice_enabled { get; set; }
        public object initial_velocity { get; set; }
        public object custom_velocity { get; set; }
        public string use_custom_velocity { get; set; }
        public object iterations_to_average { get; set; }
        public int order { get; set; }
    }

    public class EmailNotifications
    {
        public int where_i_am_involved { get; set; }
        public int story_added { get; set; }
        public int story_deleted { get; set; }
        public int story_completed { get; set; }
        public int story_verified { get; set; }
        public int story_accepted { get; set; }
        public int story_rejected { get; set; }
        public int story_released { get; set; }
        public int story_blocked { get; set; }
        public int story_unblocked { get; set; }
        public int task_assigned { get; set; }
        public int task_completed { get; set; }
        public int file_attached { get; set; }
        public int has_deadline { get; set; }
        public int iteration_will_be_move_to_history { get; set; }
        public int iteration_moved_to_history { get; set; }
        public int morning_digest_daily { get; set; }
        public int morning_digest_monday { get; set; }
        public int morning_digest_weekday { get; set; }
    }

    public class Defaults
    {
        public string type { get; set; }
        public int project_id { get; set; }
        public int importance { get; set; }
        public bool trend { get; set; }
        public bool startToZero { get; set; }
        public bool split { get; set; }
        public string burndown { get; set; }
        public string velocity { get; set; }
        public string item_position { get; set; }
        public string task_position { get; set; }
    }

    public class ProductsResult
    {
        public List<Product> content { get; set; }
        public string code { get; set; }
        public string redirect { get; set; }
        public int time { get; set; }
    }
}

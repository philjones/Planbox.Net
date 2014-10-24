namespace Planbox.Net
{
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public string alias { get; set; }
        public object description { get; set; }
        public string tags { get; set; }
        public int product_id { get; set; }
        public string manual_points_velocity { get; set; }
        public string manual_hours_velocity { get; set; }
        public bool deleted { get; set; }
        public int initiative_id { get; set; }
    }
}

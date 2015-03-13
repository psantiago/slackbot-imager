namespace SlackbotImager.Models
{
    public class SlackUser
    {
        // ReSharper disable InconsistentNaming
        public string id { get; set; }
        public string name { get; set; }
        public string deleted { get; set; }
        public string status { get; set; }
        public string color { get; set; }
        public string real_name { get; set; }
        public string tz { get; set; }
        public string tz_label { get; set; }
        public string tz_offset { get; set; }
        public string is_admin { get; set; }
        public string is_owner { get; set; }
        public string is_primary_owner { get; set; }
        public string is_restricted { get; set; }
        public string is_ultra_restricted { get; set; }
        public string is_bot { get; set; }
        public string has_files { get; set; }
        // ReSharper restore InconsistentNaming 
    }
}
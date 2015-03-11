using System.Collections.Generic;

namespace SlackbotImager.Models
{
    // ReSharper disable InconsistentNaming
    public class SlackResponse
    {
        public string text { get; set; }

        public List<SlackAttachment> attachments { get; set; } 
    }

    public class SlackAttachment
    {
        public string fallback { get; set; }
        public string image_url { get; set; }
    }
    // ReSharper restore InconsistentNaming
}
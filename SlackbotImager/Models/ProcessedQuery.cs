using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SlackbotImager.Models
{
    public class ProcessedQuery
    {
        private static readonly Regex Regex = new Regex(@"slackbot ??(lucky)? (image|animate) me (.*)");
        public ProcessedQuery(string text)
        {
            var match = Regex.Match(text.ToLowerInvariant());

            IsLucky = match.Groups[1].Success;
            IsAnimated = match.Groups[2].Value == "animate";
            Query = match.Groups[3].Value;
            IsCatQuery = Query.Contains("cat");
        }

        public bool IsLucky { get; set; }
        public bool IsAnimated { get; set; }
        public bool IsCatQuery { get; set; }
        public string Query { get; set; }
    }
}
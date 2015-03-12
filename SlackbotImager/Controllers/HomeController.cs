using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SlackbotImager.Models;

namespace SlackbotImager.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return Content("Here be dragons");
        }

        [HttpPost]
        public ActionResult Index(SlackRequest request)
        {
            var processedQuery = new ProcessedQuery(request.text);

            if (processedQuery.IsCatQuery)
            {
                //TODO - call & return from cat api instead
            }

            return GoogleImageSearch(processedQuery);
        }

        private JsonResult GoogleImageSearch(ProcessedQuery processedQuery)
        {
            var filetype = processedQuery.IsAnimated ? "&as_filetype=gif" : "";

            var random = new Random();

            using (var client = new WebClient())
            {
                var response = client.DownloadString(
                    String.Format("http://ajax.googleapis.com/ajax/services/search/images?v=1.0&rsz={3}&start={2}&safe=active{0}&q={1}",
                    filetype,
                    processedQuery.Query,
                    0,
                    processedQuery.IsLucky ? 1 : 6));

                dynamic test = JsonConvert.DeserializeObject(response);

                var imageToUse = test.responseData.results[random.Next(0, test.responseData.results.Count)];

                var slackResponse = new SlackResponse
                {
                    text = "Here's an image of " + processedQuery.Query,
                    attachments = new List<SlackAttachment> { new SlackAttachment { fallback = imageToUse.contentNoFormatting ?? "", image_url = imageToUse.unescapedUrl } }
                };

                return Json(slackResponse, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
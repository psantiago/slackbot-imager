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
            var filetype = request.text.Contains("slackbot animate me") ? "&as_filetype=gif" : "";

            var query = request.text.Replace("slackbot animate me", "").Replace("slackbot image me", "");

            var random = new Random();

            using (var client = new WebClient())
            {
                var response = client.DownloadString(
                    String.Format("http://ajax.googleapis.com/ajax/services/search/images?v=1.0&rsz=6&start={2}&safe=active{0}&q={1}",
                    filetype,
                    query,
                    0));

                dynamic test = JsonConvert.DeserializeObject(response);

                var imageToUse = test.responseData.results[random.Next(0, test.responseData.results.Count)];

                var slackResponse = new SlackResponse
                {
                    text = "Here's an image of " + query,
                    attachments = new List<SlackAttachment> { new SlackAttachment { fallback = imageToUse.contentNoFormatting ?? "", image_url = imageToUse.unescapedUrl } }
                };

                return Json(slackResponse, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
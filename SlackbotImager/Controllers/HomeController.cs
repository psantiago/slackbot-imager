using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            using (var client = new WebClient())
            {
                var response = client.DownloadString("http://ajax.googleapis.com/ajax/services/search/images?v=1.0&rsz=8&start=0&safe=active&as_filetype=gif&q=facepalm");

                dynamic test = JsonConvert.DeserializeObject(response);

                var imageToUse = test.responseData.results[new Random().Next(0, test.responseData.results.Count)];

                var slackResponse = new SlackResponse
                {
                    text = "hello",
                    attachments = new List<SlackAttachment> { new SlackAttachment { fallback = "meow", image_url = imageToUse.unescapedUrl } }
                };

                return Json(slackResponse, JsonRequestBehavior.AllowGet);
            }

            return Content("Here be dragons");
        }
    }
}
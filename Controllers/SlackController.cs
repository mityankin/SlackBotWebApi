using Newtonsoft.Json;
using SlackBotWebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Xml.Serialization;

namespace SlackBotWebApi.Controllers
{
    public class SlackController : ApiController
    {


        private SlackService _svc;

        public SlackController()
        {
            _svc = new SlackService();
        }


        [HttpPost]
        public async Task<IHttpActionResult> Talk()
        {

            HttpContent requestContent = Request.Content;
            string jsonContent = requestContent.ReadAsStringAsync().Result;
            string[] t = jsonContent.Split('&');
            Dictionary<string, string> dictionary = t.ToDictionary(s => s.Split('=')[0], s => (s.Split('=')[1]));
            SlackRequest request = new SlackRequest() { Token = dictionary["token"], Text = WebUtility.UrlDecode(dictionary["text"]) } ;
 
            if (!request.Token.Equals(Constants.SlackToken))
            {
                return new StatusCodeResult(HttpStatusCode.Unauthorized, Request);
            }

            var result = await _svc.ProcessRequestAsync(request);

            return Ok(result);
        }









    }
}

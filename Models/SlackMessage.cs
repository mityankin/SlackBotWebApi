using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackBotWebApi.Models
{
    public class SlackMessage
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
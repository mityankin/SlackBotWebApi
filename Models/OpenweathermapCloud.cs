using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackBotWebApi.Models
{
    public class OpenweathermapCloud
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
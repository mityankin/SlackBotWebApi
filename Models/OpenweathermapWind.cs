using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackBotWebApi.Models
{
    public class OpenweathermapWind
    {
        [JsonProperty("speed")]
        public String Speed { get; set; }
        [JsonProperty("deg")]
        public String Deg { get; set; }
        [JsonProperty("gust")]
        public String Gust { get; set; }
    }
}
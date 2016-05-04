using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackBotWebApi.Models
{
    public class OpenweathermapWeather
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("main")]
        public string State { get; set; }
        [JsonProperty("description")]
        public string Ddescription { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
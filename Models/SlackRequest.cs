using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackBotWebApi.Models
{
    public class SlackRequest
    {
        public string Token { get; set; }
        public string Text { get; set; }
    }
}
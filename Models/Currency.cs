using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SlackBotWebApi.Models
{

//    [XmlRoot(ElementName = "currency")]
    public class Currency
    {
        [XmlElement(ElementName = "r030")]
        public string R030 { get; set; }
        [XmlElement(ElementName = "txt")]
        public string Txt { get; set; }
        [XmlElement(ElementName = "rate")]
        public string Rate { get; set; }
        [XmlElement(ElementName = "cc")]
        public string Cc { get; set; }
        [XmlElement(ElementName = "exchangedate")]
        public string Exchangedate { get; set; }
        }
    }
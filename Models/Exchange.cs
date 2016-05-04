using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SlackBotWebApi.Models
{
    [XmlRoot(ElementName = "exchange")]
    public class Exchange
    {
        [XmlElement(ElementName = "currency")]
        public List<Currency> Currencys { get; set; }

        public override string ToString()
        {
            string _ex = null;

            foreach(Currency curr in Currencys)
            {
                _ex += " " + curr.Txt + " = " + curr.Rate ;
            }
            return _ex;
        }

    }
}
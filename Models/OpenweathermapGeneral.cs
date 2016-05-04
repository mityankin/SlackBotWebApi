using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackBotWebApi.Models
{
    public class OpenweathermapGeneral
    {
        [JsonProperty("coord")]
        public OpenweathermapCoord Coordinates { get; set; }
        [JsonProperty("weather")]
        public IList<OpenweathermapWeather> WeatherDetails { get; set; }
        [JsonProperty("base")]
        public string BaseStations { get; set; }
        [JsonProperty("main")]
        public OpenweathermapMain Temperature { get; set; }
        [JsonProperty("wind")]
        public OpenweathermapWind WindValue { get; set; }
        [JsonProperty("clouds")]
        public OpenweathermapCloud CloudsValue { get; set; }
        [JsonProperty("dt")]
        public int Dt { get; set; }
        [JsonProperty("sys")]
        public OpenweathermapSys SystemValue { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("cod")]
        public int Cod { get; set; }
        [JsonProperty("message")]
        public String Message { get; set; }

        public override String ToString()
        {
            return $"Погода в {Name} ({SystemValue.Country}): средняя температура - {Temperature.Temp} градусов по цельсию, максимальная - {Temperature.Temp_max} градусов по цельсию, минимальная {Temperature.Temp_min} градусов по цельсию, скорость ветра  {WindValue.Speed} м\\с ";
        }
    }
}
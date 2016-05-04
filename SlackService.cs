using Newtonsoft.Json;
using SlackBotWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace SlackBotWebApi
{
    public class SlackService
    {
        public async Task<string> ProcessRequestAsync(SlackRequest request)
        {
            string responseFromServer = null;

            if (request.Text.Contains("Bot tell me the weather"))
            {
                responseFromServer = await SlackCommunicator.GetWeather(request.Text.Substring(28));
            }
               

            if (request.Text.Contains("Bot tell me the course"))
            {
                responseFromServer = await SlackCommunicator.GetExchange(request.Text.Substring(27));
            }
                

            if (request.Text.Contains("help me"))
            {
                responseFromServer = await SlackCommunicator.SendSlackAnswer("You can ask 'Bot tell me the course:value' or 'Bot tell me the weather:value'? weather value = cyti, course value = date (YYYYMMDD) ");
            }
               

            if (responseFromServer == null)
            {
                return await SlackCommunicator.SendSlackAnswer("You can ask 'Bot tell me the course:value' or 'Bot tell me the weather:value'? weather value = cyti, course value = date (YYYYMMDD). And You tall me " + request.Text);


            }
               

            var textResult = await SlackCommunicator.SendSlackAnswer(responseFromServer);

            return textResult;
        }

        private static class SlackCommunicator
        {
            private static readonly Uri SlackPostUrl =
            new Uri("https://hooks.slack.com/services/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");


            public static async Task<string> SendSlackAnswer(string answer)
            {
                using (var client = new HttpClient())
                {
                    SlackMessage message = new SlackMessage() { Username = "bot", Text = answer };

                    var json = JsonConvert.SerializeObject(new SlackMessage() { Username = "bot", Text = answer });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("https://hooks.slack.com/services/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", content);
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                       return Constants.CustomErrorMessage;
                    }                     

                    var responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                }
            }

            public static async Task<string> GetWeather(string city)
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(20);
                    var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&APPID=ebeecf1b5d49cc9e57371f1c75fc2d0b");
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                     return Constants.CustomErrorMessage;
                    }                      

                    try
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var myWeather = JsonConvert.DeserializeObject<OpenweathermapGeneral>(responseContent);

                        if (myWeather.Cod != 200)
                        {
                            return Constants.CustomErrorMessage;
                        }
                            

                        var result = myWeather.ToString();
                        return result;
                    }
                    catch
                    {
                        return Constants.CustomErrorMessage;
                    }
                }
            }

            public static async Task<string> GetExchange(string date)
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(20);
                    var response = await client.GetAsync($"http://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date={date}");
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                      return Constants.CustomErrorMessage;
                    }
                        
                    var responseContentStream = await response.Content.ReadAsStreamAsync();

                    try
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Exchange));
                        Exchange exchange = (Exchange)serializer.Deserialize(responseContentStream);
                        var result = exchange.ToString();

                        return result;
                    }
                    catch
                    {
                        return Constants.CustomErrorMessage;
                    }
                }
            }
        }
    }
}
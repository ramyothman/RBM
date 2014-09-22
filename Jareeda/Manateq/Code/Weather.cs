using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Linq.Expressions;
namespace ManatiqFrontEnd.Code
{
    static class Weather
    {
        private static string AppID = "161977f270a1ff781eb6c629a4bddf0b";

        public static List<WeatherDetails> GetWeather(string location)
        {
            string url = string.Format
                ("http://api.openweathermap.org/data/2.5/group?id={0}&type=accurate&units=metric&cnt=3&appid={1}",
                "108410,110336,104515", AppID);
            HttpWebRequest http = (HttpWebRequest)HttpWebRequest.Create(url);
            try
            {
                WebResponse r = http.GetResponse();
                HttpWebResponse response = (HttpWebResponse)r;
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {

                    string responseXML = sr.ReadToEnd();
                    if (!(responseXML.Contains("message") && responseXML.Contains("cod")))
                    {
                        return GetWeatherInfo(JSON.WeatherJson.GetWeather(responseXML));
                    }
                    else
                    {
                        return new List<WeatherDetails>();
                    }
                    // more stuff
                }
            }
            catch (Exception ex)
            {
                return new List<WeatherDetails>();
            }
        }

        private static List<WeatherDetails> GetWeatherInfo(List<JSON.WeatherJson> list)
        {
            IEnumerable<WeatherDetails> w = list.Select((el) =>
                new WeatherDetails
                {
                    City = el.name,
                    Humidity = el.main.humidity + "%",
                    MaxTemperature = el.main.temp_max + "°",
                    MinTemperature = el.main.temp_min + "°",
                    Temperature = Math.Round(el.main.temp, 0) + "°",
                    Weather = el.weather[0].main,
                    WeatherIcon = WeatherIconPath(el.weather[0].icon, el.weather[0].id),
                    WindDirection = el.wind.deg.ToString(),
                    WindSpeed = el.wind.speed + "mps"
                });


            return w.ToList();
        }

        private static string DayOfTheWeek(XElement el)
        {
            DayOfWeek dW = Convert.ToDateTime(el.Attribute("day").Value).DayOfWeek;
            return dW.ToString();
        }

        private static string WeatherIconPath(XElement el)
        {
            string symbolVar = el.Element("symbol").Attribute("var").Value;
            string symbolNumber = el.Element("symbol").Attribute("number").Value;
            string dayOrNight = symbolVar.ElementAt(2).ToString(); // d or n
            return String.Format("/WeatherIcons/{0}{1}.png", symbolNumber, dayOrNight);
        }

        private static string WeatherIconPath(string el,string id)
        {
            string symbolNumber = el.Substring(0, el.Length - 1);
            string dayOrNight = el.Substring(el.Length - 1, 1); // d or n
            return String.Format("/WeatherIcons/{0}{1}.png", id, dayOrNight);
        }
    }
}
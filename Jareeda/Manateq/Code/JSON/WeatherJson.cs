using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ManatiqFrontEnd.Code.JSON
{
    public class WeatherJson
    {
        public int id;
        public decimal dt;
        public string name;

        public coordJson coord;
        public sysJson sys;
        public List<weatherItemJson> weather;
        public mainJson main;
        public windJson wind;
        public cloudsJson clouds;

        public static List<WeatherJson> GetWeather(string list)
        {
            JsonSerializer serializer = new JsonSerializer();

            StringReader reader = new StringReader(list);
            using (JsonReader jsonReader = new JsonTextReader(reader))
            {
                
                WeatherListJson p = (WeatherListJson)serializer.Deserialize(jsonReader, typeof(WeatherListJson));
                if(p != null)
                    return p.list;
            }
            return new List<WeatherJson>();
        }
    }

    public class coordJson
    {
        public decimal lon;
        public decimal lat;
    }

    public class sysJson
    {
        public int type;
        public int id;
        public string message;
        public string country;
        public int sunrise;
        public int sunset;
    }

    public class weatherItemJson
    {
        public string id;
        public string main;
        public string description;
        public string icon;
    }

    public class mainJson
    {
        public decimal temp;
        public decimal pressure;
        public decimal humidity;
        public decimal temp_min;
        public decimal temp_max;
    }

    public class windJson
    {
        public decimal speed;
        public decimal deg;
    }

    public class cloudsJson
    {
        public decimal all;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManatiqFrontEnd.Code
{
    class WeatherDetails
    {
        public string City { get; set; }
        public string Weather { get; set; }
        public string WeatherIcon { get; set; }
        public string WeatherDay { get; set; }
        public string Temperature { get; set; }
        public string MaxTemperature { get; set; }
        public string MinTemperature { get; set; }
        public string WindDirection { get; set; }
        public string WindSpeed { get; set; }
        public string Humidity { get; set; }

        public string CityArabic
        {
            get
            {
                switch (City)
                {
                    case "Riyadh":
                        return "الرياض";
                    case "Jeddah":
                        return "جدة";
                    case "Mecca":
                        return "مكة";
                    case "Ad Dammam":
                        return "الدمام";
                }
                return "";
            }
        }
    }
}
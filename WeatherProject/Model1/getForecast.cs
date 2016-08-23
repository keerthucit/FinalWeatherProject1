using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WeatherProject.Model1
{
    public class getForecast
    {
        public Object getCurrentWeatherD(string city_name, string temp_units)
        {
            if (city_name != null)
            {
                //var temp_units = "metric";
                var cty_name = city_name;
                string appid = "292ead3582f8d66eb3f191975ead9a9d";
                string url = "http://api.openweathermap.org/data/2.5/forecast?q=" + cty_name + "&APPID=" + appid + "&units=" + temp_units;
                //synchronous client.
                var client = new WebClient();
                var content = client.DownloadString(url);
                var jsonContent = JsonConvert.DeserializeObject<WeatherModelD>(content);
                return jsonContent;
            }
            return null;
        }
    }
}
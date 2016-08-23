using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Net;

namespace WeatherProject.Models
{
    public class getWeatherDat
    {

        public Object getCurrentWeather(string city_name)
        {
            var temp_units = "metric";
            var cty_name = city_name;
            string appid = "292ead3582f8d66eb3f191975ead9a9d";
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + cty_name + "&APPID=" + appid + "&units=" + temp_units;
            //synchronous client.
            var client = new WebClient();
            var content = client.DownloadString(url);
            var jsonContent = JsonConvert.DeserializeObject<WeatherModel>(content);
            return jsonContent;
        }      
    }
}
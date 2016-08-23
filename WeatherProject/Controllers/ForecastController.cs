using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherProject.Model1;

namespace WeatherProject.Controllers
{
    public class ForecastController : Controller
    {
        //
        // GET: /Forecast/

        public JsonResult getCurrWeatherD(string city_name, string temp_units)
        {
            getForecast weath = new getForecast();
            var xx = Json(weath.getCurrentWeatherD(city_name, temp_units), JsonRequestBehavior.AllowGet);
            return xx;
        }
    }
}

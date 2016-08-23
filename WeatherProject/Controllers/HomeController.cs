using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherProject.Model1;
using WeatherProject.Models;

namespace WeatherProject.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Homedaily()
        {
            return View();
        }
        public ActionResult Contactus()
        {
            return View();
        }


        public ActionResult Index(string last_searched)
        {
            //WeatherModel wm = new WeatherModel();
            //wm.name = last_searched;
            //ViewBag.NameofCity = wm.name;

            // getForecast vv = new getForecast();

            //   vv.getCurrentWeatherD(last_searched);

            return View();
        }

        public ActionResult Indexmain(string last_searched)
        {
            return View();
        }

        public JsonResult getCurrWeather(string city_name)
        {
            getWeatherDat weath = new getWeatherDat();
            var xx = Json(weath.getCurrentWeather(city_name), JsonRequestBehavior.AllowGet);
            return xx;
        }

    }
}

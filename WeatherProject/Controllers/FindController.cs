using WeatherProject.Models;
using WeatherProject.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace Find_page.Controllers
{
    public class FindController : Controller
    {
        WeatherDataEntities dc = new WeatherDataEntities();
        // GET: Find
        public ActionResult Find()
        {
            return View();
        }
        public JsonResult getCurrWeather(string city_name)
        {
            getWeatherDat weath = new getWeatherDat();
            var xx = Json(weath.getCurrentWeather(city_name), JsonRequestBehavior.AllowGet);
            return xx;
        }


        public ActionResult Favorites()
        {
            if (ModelState.IsValid) // this is check validity
            {
                if (Session["LoggedEmail"] != null)
                {
                    string LoggedEmail = Session["LoggedEmail"].ToString();
                    return View(dc.favourites.Where(x => x.Email == LoggedEmail).ToList());
                }
                else
                {
                    string fv = "Not Found";
                    return Json(fv, JsonRequestBehavior.AllowGet);
                }
            }
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Favorites(string city_name, string country_code)
        {
            using (WeatherDataEntities dc = new WeatherDataEntities())
            {
                var favdb = dc.favourites.ToList<favourite>();
                var email = Session["LoggedEmail"];
                var pass = Session["LoggedUsername"];
                int favCount;
                if (System.Web.HttpContext.Current.Session["LoggedUsername"] != null)
                {
                    favCount = favdb.Where(fv => fv.Email == email.ToString() && city_name.Equals(fv.CityName)).Count();
                    if (favCount > 0)
                    {
                        string fv = "Favourite city already added..!";
                        return Json(fv, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        favourite fav = new favourite();
                        fav.CityName = city_name;
                        fav.Email = email.ToString();
                        fav.Zipcode = country_code;
                        dc.favourites.Add(fav);
                        dc.SaveChanges();
                        string fv = "Favourite city saved successfully";
                        return Json(fv, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }
            }
        }

        [System.Web.Mvc.HttpDelete]
        public ActionResult Delete(string city)
        {
            using (WeatherDataEntities dc = new WeatherDataEntities())

                if (ModelState.IsValid) // this is check validity
                {
                    dc.favourites.Remove(dc.favourites.Where(c => c.CityName.ToUpper() == city.ToUpper()).FirstOrDefault());
                    dc.SaveChanges();
                }

            string fv = "City Removed";
            return Json(fv, JsonRequestBehavior.AllowGet);
        }

    }
}



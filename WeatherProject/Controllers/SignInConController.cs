using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Web.Security;
using System.Security.Permissions;
using System.Web.Services.Description;
using System.Net;
using WeatherProject.Models.DB;

namespace WeatherProject.Controllers
{
    public class SignInConController : Controller
    {
        // GET: SignInCon
        public ActionResult SignIn()
        {
            ViewBag.ErrorMessage = "";
            return View();
        }


        [HttpPost]
        public ActionResult SignIn(register u)
        {

            if (ModelState.IsValid) // this is check validity
            {
                using (WeatherDataEntities dc = new WeatherDataEntities())
                {
                    var v = dc.registers.Where(a => a.Email.Equals(u.Email) && a.Password.Equals(u.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LoggedEmail"] = v.Email.ToString();
                        Session["LoggedUsername"] = v.UserName.ToString();
                        TempData["Success"] = "You're now Signed in";
                        return RedirectToAction("MyHome", "SignInCon");
                    }
                    else
                    {
                        TempData["Fail"] = "Invalid Email or password..!";
                        return RedirectToAction("SignIn", "SignInCon");
                    }
                }
            }
            return View(u);

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            if (Request.Cookies["MyCookie"] != null)
            {
                var c = new HttpCookie("MyCookie");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }
            return RedirectToAction("SignIn", "SignInCon");
        }

        [HttpGet]
        public ActionResult MyHome()
        {
            var email = Session["LoggedEmail"];
            var pass = Session["LoggedUsername"];
            if (System.Web.HttpContext.Current.Session["LoggedEmail"] != null)
            {
                if (TempData["Success"] != null)
                {
                    TempData["Success"] = "You're now Signed in";
                }
                if (TempData["Success"] == null && TempData["Fail"] == null && TempData["editComplete"] == null)
                {
                    TempData["Fail"] = "You're Already Signed in";
                }
                return View();
            }
            else
            {
                return RedirectToAction("SignIn", "SignInCon");
            }
        }

        public ActionResult EditFields()
        {
            var email = Session["LoggedEmail"];
            var pass = Session["LoggedUsername"];
            String emailofuser = email.ToString();
            using (WeatherDataEntities dc = new WeatherDataEntities())
            {
                if (email == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
                register register = dc.registers.Find(emailofuser);
                if (register == null)
                {
                    return HttpNotFound();
                }
                return View(register);
            }
        }

        [HttpPost]
        public ActionResult EditFields(string Phone, string Address1, string Address2, string City, string State, string Country, string Zipcode)
        {
            using (WeatherDataEntities dc = new WeatherDataEntities())
                if (ModelState.IsValid) // this is check validity
                {
                    SqlConnection con = new SqlConnection(@"data source = indradb.database.windows.net; initial catalog = WeatherData; persist security info = True; user id = dbadmin; password = Admin123;");
                   // SqlConnection con = new SqlConnection(@"Data Source=192.168.10.156\SQL2008;initial catalog=WeatherData;persist security info=True;user id=sa;password=admin@2008;");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update register set Phone = '" + Phone + "',Address1= '" + Address1 + "',Address2= '" + Address2 + "',City= '" + City + "',State= '" + State + "',Country= '" + Country + "',Zipcode= '" + Zipcode + "'where Email='" + Session["LoggedEmail"].ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            TempData["editComplete"] = "Data Saved";
            return RedirectToAction("MyHome", "SignInCon");
        }
    }
}

using WeatherProject.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Permissions;
using System.Web.Services.Description;
using System.Net;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Configuration;
using System.Text;
namespace WeatherProject.Controllers
{
    public class ChangePasswordController : Controller
    {
        // GET: ChangePassword
        public ActionResult Index()
        {
            if (Session["LoggedEmail"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("SignIn", "SignInCon");
            }

        }
        [HttpPost]
        public ActionResult Index(string password)
        {
            using (WeatherDataEntities dc = new WeatherDataEntities())

                if (ModelState.IsValid) // this is check validity
                {
                    if ((password != null))
                    {
                        SqlConnection con = new SqlConnection(@"data source = indradb.database.windows.net; initial catalog = WeatherData; persist security info = True; user id = dbadmin; password = Admin123;");
                        //SqlConnection con = new SqlConnection(@"Data Source=192.168.10.156\SQL2008;initial catalog=WeatherData;persist security info=True;user id=sa;password=admin@2008;");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Update register set Password = '" + password + "'where Email='" + Session["LoggedEmail"].ToString() + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        TempData["editComplete"] = "Password Changed";
                    }
                }
            return RedirectToAction("MyHome", "SignInCon");


        }
    }
}

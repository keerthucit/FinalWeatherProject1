using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using WeatherProject.Models.DB;
using System.Web.Security;
using System.Security.Permissions;
using System.Web.Services.Description;



namespace WeatherProject.Controllers
{
    public class ForgotPasswordConController : Controller
    {

        // GET: ForgotPasswordCon
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
           
            if (ModelState.IsValid)
            {
                using (WeatherDataEntities dc = new WeatherDataEntities())
                {
                    var v = dc.registers.Where(a => a.Email.Equals(email)).FirstOrDefault();
                    if (v != null)
                    {
                        string strNewPassword = Membership.GeneratePassword(10, 0).ToString();
                        
                        // SqlConnection con = new SqlConnection(@"Data Source=192.168.10.156\SQL2008;initial catalog=WeatherData;persist security info=True;user id=sa;password=admin@2008;");
                        SqlConnection con = new SqlConnection(@"data source = indradb.database.windows.net; initial catalog = WeatherData; persist security info = True; user id = dbadmin; password = Admin123;");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Update register set Password = '" + strNewPassword + "'where Email='" + email + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        // to send the random password in email  

                        MailMessage mail = new MailMessage();
                        mail.To.Add(email);
                        mail.From = new MailAddress("darshana.moghe21@gmail.com");
                        mail.Subject = "DoNotReply";
                        mail.Body = "<b>Hello..!</b> <br>Kindly use the given password and login to you account and enjoy your weather journey.<br> Your New Password is <b>" + strNewPassword + "</b>";
                        mail.IsBodyHtml = true;

                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        smtp.EnableSsl = true;
                        ICredentialsByHost credentials = new NetworkCredential("darshana.moghe21@gmail.com", "fabme@21");
                        smtp.Credentials = credentials;
                        smtp.Send(mail);
                        TempData["Success"] = "Mail Sent!";
                        return RedirectToAction("SignIn", "SignInCon");
                    }
                    else
                    {
                        TempData["Fail"] = "It Seems you have not yet registered. Please Register with us..!";
                        return RedirectToAction("SignIn", "SignInCon");
                    }
                }

            }
            return View();
        }
    }
}
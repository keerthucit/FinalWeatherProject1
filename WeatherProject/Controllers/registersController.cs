using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeatherProject.Models.DB;

namespace WeatherProject.Controllers
{
    public class registersController : Controller
    {
        private WeatherDataEntities db = new WeatherDataEntities();

        // GET: registers
        public ActionResult Index()
        {
            return View();
        }

        // GET: registers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            register register = db.registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // GET: registers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: registers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "Email,UserName,FullName,Password,ConfirmPassword,Phone,Address1,Address2,City,State,Country,Zipcode")] register register)
        {
            if (ModelState.IsValid)
            {
                db.registers.Add(register);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(register);
        }

        // GET: registers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            register register = db.registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // POST: registers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,UserName,FullName,Password,ConfirmPassword,Phone,Address1,Address2,City,State,Country,Zipcode")] register register)
        {
            if (ModelState.IsValid)
            {
                db.Entry(register).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(register);
        }

        // GET: registers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            register register = db.registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // POST: registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            register register = db.registers.Find(id);
            db.registers.Remove(register);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

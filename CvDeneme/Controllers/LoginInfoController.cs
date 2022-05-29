using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Windows;
using CvDeneme.Models;

namespace CvDeneme.Controllers
{
    public class LoginInfoController : Controller
    {
        private Entities db = new Entities();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginInfo loginInfo)
        {
            var l = db.LoginInfo.FirstOrDefault(a => a.Email == loginInfo.Email && a.Password == loginInfo.Password);
            if (l != null)
            {
                FormsAuthentication.SetAuthCookie(l.Email, false);
                return RedirectToAction("Index", "CvInformation");
            }
            else
            {
                string message1 = "Email veya parolayı yanlış girdiniz.";
                MessageBox.Show(message1);
                return RedirectToAction("Login");
            }
;        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("NotLogin");
        }
        public ActionResult Wait() { return View(); }
        public ActionResult NotLogin() { return View(); }
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

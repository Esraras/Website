using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CvDeneme.Models;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace CvDeneme.Controllers
{
    public class CvInformationController : Controller
    {
        private Entities db = new Entities();

        [_SessionControl]
        public ActionResult Index()
        {
            return View(db.CvInformation.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CvInformation cvInformation = db.CvInformation.Find(id);
            if (cvInformation == null)
            {
                return HttpNotFound();
            }
            return View(cvInformation);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LName,Phone,Mail,Adress,Position,CoverLetter,Education,Experience,Skills,Certificate,Reference,Hobby,Image,Documan")] CvInformation cvInformation)
        {
            if (Request.Files[0].ContentLength > 0)
            {
                string ImageName = Path.GetFileName(Request.Files[0].FileName);
                string Extension = Path.GetExtension(Request.Files[0].FileName);
                string Way = "~/Image/" + ImageName + Extension;
                Request.Files[0].SaveAs(Server.MapPath(Way));
                cvInformation.Image = "/Image/" + ImageName + Extension;
            }
            if (Request.Files[1].ContentLength > 0)
            {
                string DocumentName = Path.GetFileName(Request.Files[1].FileName);
                string Extension2 = Path.GetExtension(Request.Files[1].FileName);
                string Way2 = "~/Files/" + DocumentName + Extension2;
                Request.Files[1].SaveAs(Server.MapPath(Way2));
                cvInformation.Documan = "/Files/" + DocumentName + Extension2;
            }

            if (ModelState.IsValid)
            {
                db.CvInformation.Add(cvInformation);
                db.SaveChanges();
                string message = "Bilgiler Eklendi";
                MessageBox.Show(message);
                return RedirectToAction("Create");
            }
            return View(cvInformation);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CvInformation cvInformation = db.CvInformation.Find(id);
            if (cvInformation == null)
            {
                return HttpNotFound();
            }
            return View(cvInformation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CvInformation cvInformation = db.CvInformation.Find(id);
            db.CvInformation.Remove(cvInformation);
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

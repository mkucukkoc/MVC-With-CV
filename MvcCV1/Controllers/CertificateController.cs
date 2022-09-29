using MvcCV1.Models.Entity;
using MvcCV1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV1.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        GenericRepository<Certificate> repo = new GenericRepository<Certificate>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult EditCertificate(int id)
        {
            var skills = repo.Find(x => x.CertficiateID == id);
            return View(skills);
        }
        [HttpPost]
        public ActionResult EditCertificate(Certificate t)
        {
            var certificate = repo.Find(x => x.CertficiateID == t.CertficiateID);
            certificate.Description = t.Description;
            certificate.Date = t.Date;
            certificate.Institution = t.Institution;
            repo.TUpdate(certificate);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCertificate(int id)
        {
            Certificate t = repo.Find(x => x.CertficiateID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddCertificate(Certificate certificate)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCertificate");
            }
            repo.TAdd(certificate);
            return RedirectToAction("Index");

        }
    }
}
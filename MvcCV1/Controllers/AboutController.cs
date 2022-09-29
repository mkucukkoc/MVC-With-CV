using MvcCV1.Models.Entity;
using MvcCV1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV1.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        GenericRepository<About> repo = new GenericRepository<About>();

        public ActionResult Index()
        {
            var vaalues = repo.List();
            return View(vaalues);
        }
        [HttpGet]
        public ActionResult EditAbout(int id)
        {
            var skills = repo.Find(x => x.AboutID == id);
            return View(skills);
        }
        [HttpPost]
        public ActionResult EditAbout(About t)
        {
            var certificate = repo.Find(x => x.AboutID == t.AboutID);
            certificate.Name = t.Name;
            certificate.Surname = t.Surname;
            certificate.Address = t.Address;
            certificate.Phone = t.Phone;
            certificate.Mail = t.Mail;
            certificate.Description = t.Description;
            certificate.Url = t.Url;
            repo.TUpdate(certificate);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAbout(int id)
        {
            About t = repo.Find(x => x.AboutID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddAbout(About certificate)
        {
            if (!ModelState.IsValid)
            {
                return View("AddAbout");
            }
            repo.TAdd(certificate);
            return RedirectToAction("Index");

        }
    }
}
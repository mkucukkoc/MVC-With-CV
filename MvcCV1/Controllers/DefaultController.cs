using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV1.Models.Entity;

namespace MvcCV1.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var values = db.About.ToList();
            return View(values);
        }
        public PartialViewResult SocialMedia()
        {
            var values = db.SocialMedia.ToList();
            return PartialView(values);
        }
        public PartialViewResult Experience()
        {
            var values = db.Experience.ToList();
            return PartialView(values);
        }
        public PartialViewResult Education()
        {
            var values = db.Education.ToList();
            return PartialView(values);
        }
        public PartialViewResult Skill()
        {
            var values = db.Skills.ToList();
            return PartialView(values);
        }
        public PartialViewResult Interest()
        {
            var values = db.Interests.ToList();
            return PartialView(values);
        }
        public PartialViewResult Certificate()
        {
            var values = db.Certificate.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(Contact contact)
        {
            contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Contact.Add(contact);
            db.SaveChanges();
            return PartialView();
        }
    }
}
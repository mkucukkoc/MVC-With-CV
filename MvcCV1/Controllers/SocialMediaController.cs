using MvcCV1.Models.Entity;
using MvcCV1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV1.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        GenericRepository<SocialMedia> repo = new GenericRepository<SocialMedia>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult EditSocialMedia(int id)
        {
            var skills = repo.Find(x => x.SocialMediaID == id);
            return View(skills);
        }
        [HttpPost]
        public ActionResult EditSocialMedia(SocialMedia t)
        {
            var socialMedia = repo.Find(x => x.SocialMediaID == t.SocialMediaID);
            socialMedia.Name = t.Name;
            socialMedia.Link = t.Link;
            socialMedia.Icon = t.Icon;
            repo.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            SocialMedia t = repo.Find(x => x.SocialMediaID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddSocialMedia(SocialMedia certificate)
        {
            if (!ModelState.IsValid)
            {
                return View("AddSocialMedia");
            }
            repo.TAdd(certificate);
            return RedirectToAction("Index");

        }
    }
}
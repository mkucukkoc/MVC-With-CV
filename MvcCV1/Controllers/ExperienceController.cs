using MvcCV1.Models.Entity;
using MvcCV1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV1.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository experienceRepository = new ExperienceRepository();
        public ActionResult Index()
        {
            var values = experienceRepository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(Experience experience)
        {
            experienceRepository.TAdd(experience);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id)
        {
            Experience t = experienceRepository.Find(x=>x.ExperienceID==id);
            experienceRepository.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditExperience(int id)
        {
            Experience experience = experienceRepository.Find(x=>x.ExperienceID==id);
            return View(experience);
        }
        [HttpPost]
        public ActionResult EditExperience(Experience p)
        {
            Experience t = experienceRepository.Find(x => x.ExperienceID == p.ExperienceID);
            t.Title = p.Title;
            t.Subtitle = p.Subtitle;
            t.Date = p.Date;
            t.Description = p.Description;
            experienceRepository.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
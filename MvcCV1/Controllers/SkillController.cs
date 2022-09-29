using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV1.Models.Entity;
using MvcCV1.Repositories;

namespace MvcCV1.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        //DbCvEntities db = new DbCvEntities();
        GenericRepository<Skills> db = new GenericRepository<Skills>();
        public ActionResult Index()
        {
            var values = db.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(Skills skills)
        {
            db.TAdd(skills);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            Skills skills = db.Find(x => x.SkillID == id);
            return View(skills);
        }
        [HttpPost]
        public ActionResult EditSkill(Skills p)
        {
            Skills t = db.Find(x => x.SkillID == p.SkillID);
            t.SkillName = p.SkillName;
            t.Status1 = p.Status1;
            db.TUpdate(t);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            Skills t = db.Find(x => x.SkillID == id);
            db.TDelete(t);
            return RedirectToAction("Index");
        }
    }
}
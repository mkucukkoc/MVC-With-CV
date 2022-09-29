using MvcCV1.Models.Entity;
using MvcCV1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV1.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        // GET: Education

        GenericRepository<Education> db = new GenericRepository<Education>();
        public ActionResult Index()
        {
            var values=db.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(Education education)
        {

            if (!ModelState.IsValid)
            {
               return View("AddEducation");
            }
            db.TAdd(education);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditEducation(int id)
        {
            var skills = db.Find(x => x.EducationID == id);
            return View(skills);
        }
        [HttpPost]
        public ActionResult EditEducation(Education p)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("EditEducation");
            //}
            var t = db.Find(x => x.EducationID == p.EducationID);
            t.Title = p.Title;
            t.Subtitle1 = p.Subtitle1;
            t.Subtitle2 = p.Subtitle2;
            t.GNO = p.GNO;
            t.Date = p.Date;
            db.TUpdate(t);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            var t = db.Find(x => x.EducationID == id);
            db.TDelete(t);
            return RedirectToAction("Index");
        }
    }
}
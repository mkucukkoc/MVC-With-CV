using MvcCV1.Models.Entity;
using MvcCV1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV1.Controllers
{
    public class InterestController : Controller
    {
        // GET: Interest
        GenericRepository<Interests> repo = new GenericRepository<Interests>();
        [HttpGet]
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(Interests ınterests)
        {
            var t = repo.Find(x => x.InterestID == 1);
            t.Description1 = ınterests.Description1;
            t.Description2 = ınterests.Description2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
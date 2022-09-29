using MvcCV1.Models.Entity;
using MvcCV1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Admin> repo = new GenericRepository<Admin>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var skills = repo.Find(x => x.LoginID == id);
            return View(skills);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin t)
        {
            var certificate = repo.Find(x => x.LoginID == t.LoginID);
            certificate.UserName = t.UserName;
            certificate.Password = t.Password;
            repo.TUpdate(certificate);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            Admin t = repo.Find(x => x.LoginID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin certificate)
        {
            if (!ModelState.IsValid)
            {
                return View("AddAdmin");
            }
            repo.TAdd(certificate);
            return RedirectToAction("Index");

        }
    }
}
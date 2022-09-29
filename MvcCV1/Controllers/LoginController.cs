using MvcCV1.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCV1.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            DbCvEntities db = new DbCvEntities();
            var kullanici = db.Admin.FirstOrDefault(x=>x.UserName==admin.UserName&&x.Password==admin.Password);
            if (kullanici!=null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.UserName,false);
                Session["UserName"] = kullanici.UserName.ToString();
                return RedirectToAction("Index","Experience");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}
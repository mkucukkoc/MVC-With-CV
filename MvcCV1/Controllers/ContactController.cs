using MvcCV1.Models.Entity;
using MvcCV1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV1.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        GenericRepository<Contact> repo = new GenericRepository<Contact>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
    }
}
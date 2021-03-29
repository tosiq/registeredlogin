using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegisterLogin.Models;

namespace RegisterLogin.Controllers
{
    public class HomeController : Controller

    {
        awamEntities db = new awamEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(the_user t)
        {
            db.the_user.Add(t);
            db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("login","Home");
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(the_user e)
        {
          var f=  db.the_user.Where(a => a.email == e.email && a.password == e.password).FirstOrDefault();
            if (f!=null)
            {
                return RedirectToAction("aptech", "Home");
            }
            else
            {
                return View();
            }
           
        }
        public ActionResult aptech()
        {
            return View();
        }
    }
}
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Partial1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Partial1(Cariler p)
        {
            c.Carilers.Add(p);
            p.Durum = true;
            c.SaveChanges();
            return View("Index");
        }

       

        [HttpGet]
        public ActionResult CariLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariLogin(Cariler p)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.CariMail == p.CariMail && x.CariSifre == p.CariSifre);
            if(bilgiler!= null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index","CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Nutzername == p.Nutzername && x.Passwort == p.Passwort);
            
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Nutzername, false);
                Session["Nutzername"] = bilgiler.Nutzername.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
    }
}
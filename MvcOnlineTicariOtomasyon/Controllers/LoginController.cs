using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();
        private string code = null;
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
                TempData["ErrorMessage"] = "username or password is wrong!";
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
                //ViewBag.ErrorMessage = "UserName or password is wrong";
                //ModelState.AddModelError("", "The user name or password provided is incorrect.");
                //return View();
                TempData["ErrorMessage"] = "username or password is wrong!";
                return RedirectToAction("Index","Login");

            }
        }

       

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ForgetPassword()
        {
            return View();

        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ForgetPasswordForAdmin()
        {
            return View();

        }



        [HttpGet]
        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            return View();

        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ResetPasswordForAdmin()
        {
            return View();

        }

        public string getCode()
        {
            if (code == null)
            {
                Random rand = new Random();
                code = "";
                for (int i = 0; i < 6; i++)
                {
                    char tmp = Convert.ToChar(rand.Next(48, 58));
                    code += tmp;
                }
            }
            return code;
        }

        public ActionResult SendCode(string CariMail)
        {
            var user = c.Carilers.FirstOrDefault(x => x.CariMail.Equals(CariMail));
            if (user != null)
            {
                PasswordCode p = new PasswordCode { Userid = user.Cariid, Code = getCode() };
                c.PasswordCodes.Add(p);
                c.SaveChanges();
                string text = "<h1>Sıfırlama için kodunuz:</h1>" + getCode() + " ";
                string subject = "Parola sifirlama";
                MailMessage msg = new MailMessage("firmalogoinf@gmail.com", CariMail, subject, text);
                msg.IsBodyHtml = true;
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.UseDefaultCredentials = false;
                NetworkCredential cre = new NetworkCredential("firmalogoinf@gmail.com", "555K1818p..pp");
                sc.Credentials = cre;
                sc.EnableSsl = true;
                sc.Send(msg);
                return RedirectToAction("ResetPassword");
            }

            return RedirectToAction("Index");
        }

        public ActionResult SendCodeForAdmin(string AdminMail)
        {
            var admin = c.Admins.FirstOrDefault(x => x.AdminMail.Equals(AdminMail));
            if (admin != null)
            {
                PasswordCodeForAdmin p = new PasswordCodeForAdmin { Userid = admin.Adminid, Code = getCode() };
                c.PasswordCodeForAdmins.Add(p);
                c.SaveChanges();
                string text = "<h1>Sıfırlama için kodunuz:</h1>" + getCode() + " ";
                string subject = "Parola sifirlama";
                MailMessage msg = new MailMessage("firmalogoinf@gmail.com", AdminMail, subject, text);
                msg.IsBodyHtml = true;
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.UseDefaultCredentials = false;
                NetworkCredential cre = new NetworkCredential("firmalogoinf@gmail.com", "555K1818p..pp");
                sc.Credentials = cre;
                sc.EnableSsl = true;
                sc.Send(msg);
                return RedirectToAction("ResetPasswordForAdmin");
            }

            return RedirectToAction("Index");
        }


        public ActionResult ResetPasswordCode(string code, string CariSifre)
        {
            var passwordcode = c.PasswordCodes.FirstOrDefault(x => x.Code.Equals(code));
            if (passwordcode != null)
            {
                var user = c.Carilers.Find(passwordcode.Userid);
                user.CariSifre = CariSifre;
                //c.Carilers.Update(user);
                c.PasswordCodes.Remove(passwordcode);
                c.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        public ActionResult ResetPasswordCodeForAdmin(string code, string Passwort)
        {
            var passwordcode = c.PasswordCodeForAdmins.FirstOrDefault(x => x.Code.Equals(code));
            if (passwordcode != null)
            {
                var user = c.Admins.Find(passwordcode.Userid);
                user.Passwort = Passwort;
                //c.Carilers.Update(user);
                c.PasswordCodeForAdmins.Remove(passwordcode);
                c.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


    }
}
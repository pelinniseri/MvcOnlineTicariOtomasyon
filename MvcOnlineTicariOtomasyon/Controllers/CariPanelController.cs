using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Carilers.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.Cariid).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(degerler);
        }
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Messages.Where(x=> x.Alici==mail).OrderByDescending(y=> y.MesajID).ToList();
            var gelenMesajSayisi = c.Messages.Count(x => x.Alici == mail).ToString();
            var gidenMesajSayisi = c.Messages.Count(x => x.Gonderici == mail).ToString();
            ViewBag.gidenMesaj = gidenMesajSayisi;
            ViewBag.gelenMesaj = gelenMesajSayisi;
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Messages.Where(x => x.Gonderici == mail).OrderByDescending(y => y.MesajID).ToList();
            var gelenMesajSayisi = c.Messages.Count(x => x.Alici == mail).ToString();
            var gidenMesajSayisi = c.Messages.Count(x => x.Gonderici == mail).ToString();
            ViewBag.gidenMesaj = gidenMesajSayisi;
            ViewBag.gelenMesaj = gelenMesajSayisi;
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Messages.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CariMail"];
            var gelenMesajSayisi = c.Messages.Count(x => x.Alici == mail).ToString();
            var gidenMesajSayisi = c.Messages.Count(x => x.Gonderici == mail).ToString();
            ViewBag.gidenMesaj = gidenMesajSayisi;
            ViewBag.gelenMesaj = gelenMesajSayisi;
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gelenMesajSayisi = c.Messages.Count(x => x.Alici == mail).ToString();
            var gidenMesajSayisi = c.Messages.Count(x => x.Gonderici == mail).ToString();
            ViewBag.gidenMesaj = gidenMesajSayisi;
            ViewBag.gelenMesaj = gelenMesajSayisi;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Message m)
        {
            var mail = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = mail;
            c.Messages.Add(m);
            c.SaveChanges();
            return View();
        }
    }
}
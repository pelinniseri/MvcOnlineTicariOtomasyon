using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize(Roles = ("H"))]
    public class CariController : Controller
    {
        // GET: Cari

        Context c = new Context();
        public ActionResult Index(int sayfa=1)
        {
            var deger = c.Carilers.Where(x => x.Durum == true).ToList().ToPagedList(sayfa,4);
            return View(deger);
        }


        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCari(Cariler p)
        {
            
            c.Carilers.Add(p);
            p.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Carisil(int id)
        {
            var cari = c.Carilers.Find(id);
            cari.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir", cari);

        }

        public ActionResult CariGuncelle(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = c.Carilers.Find(p.Cariid);
            cari.CariAd = p.CariAd;
            cari.CariSoyad = p.CariSoyad;
            cari.CariSehir = p.CariSehir;
            cari.CariMail = p.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult MusteriSatis(int id)
        {
            var deger = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var cr = c.Carilers.Where(x => x.Cariid == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            
            ViewBag.cari = cr;

            return View(deger);
        }

    }
}
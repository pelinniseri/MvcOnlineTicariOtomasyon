using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using PagedList;
using PagedList.Mvc;
namespace MvcOnlineTicariOtomasyon.Controllers
{
   
    public class KategoriController : Controller
    {
        // GET: Kategori
        
        Context c = new Context();
        
        public ActionResult Index(int sayfa=1)
        {
            var degeler = c.Kategoris.ToList().ToPagedList(sayfa,4);
            return View(degeler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var cat = c.Kategoris.Find(id);
            c.Kategoris.Remove(cat);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktg = c.Kategoris.Find(k.KategoriID);
            ktg.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Deneme ()
        {
            Class3 cs=new Class3();

            cs.Kategoriler = new SelectList(c.Kategoris,"KategoriID","KategoriAd");
            cs.Urunler = new SelectList(c.Uruns, "UrunID", "UrunAd");
            return View(cs);
        }
        public JsonResult UrunGetir(int p)
        {
            var urunler = (from x in c.Uruns
                           join y in c.Kategoris
                           on x.Kategori.KategoriID equals y.KategoriID
                           where x.Kategori.KategoriID == p
                           select new
                           {
                               Text = x.UrunAd,
                               Value = x.UrunID.ToString()
                           }).ToList();
            return Json(urunler,JsonRequestBehavior.AllowGet);
        }
    }
}
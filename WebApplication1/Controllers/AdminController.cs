using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Siniflar;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }

        [HttpGet]   //Sayfa yuklendiğinde çalışacak
        public ActionResult YeniBlog()
        {

            return View();//sayfanın boş halini dondur
        }

        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);   //id den gelen degeri bul
            c.Blogs.Remove(b);          //b den gelen değerleri sil
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var b1 = c.Blogs.Find(id);
         
            return View("BlogGetir",b1);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg= c.Blogs.Find(b.ID);    //b den göndermiş olduğum id ye göre ilgili blogu bul
            blg.Aciklama = b.Aciklama;      //b den gelen açıklama değeri olcak
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();    // c degeri contexten geldiği için

            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);   //id den gelen degeri bul
            c.Yorumlars.Remove(b);          //b den gelen değerleri sil
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);    //b den göndermiş olduğum id ye göre ilgili blogu bul
            yrm.KullaniciAdi = y.KullaniciAdi;      //b den gelen açıklama değeri olcak
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            //yrm.Tarih = y.Tarih;
            c.SaveChanges();    // c degeri contexten geldiği için

            return RedirectToAction("YorumListesi");
        }


    }
}
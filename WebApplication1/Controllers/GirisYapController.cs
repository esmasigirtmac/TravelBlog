using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models.Siniflar;

namespace WebApplication1.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]      //sayfada butona tıklama islemi gerçekleşince olur
        public ActionResult Login(Admin ad)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre == ad.Sifre);
            if (bilgiler != null)       //bilgiler null degilse parametre olarak gönderdiğim ad değeri ile veri tabanındaki bilgiler eşitse bilgiler null gelmez ve işlemler gerçeklesir
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);   
                Session["Kullanici"] = bilgiler.Kullanici.ToString();
                return RedirectToAction("Index", "Admin");      //kadı sifere dogruysa admin controlundaki indexe yonlendir
            }
            else                //bilgiler null ise
            {
                
                return View();
            }

         
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","GirisYap");
        }



    }



}
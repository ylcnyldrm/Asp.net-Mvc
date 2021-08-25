
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Controllers
{
    public class HomeController:Controller
    {

        public IActionResult Index() {
            int saat = DateTime.Now.Hour;
            //Viewbag ile view içerisine veri gönderebiliriz
            ViewBag.Greeting = saat > 12 ? "İyi günler" : "Günaydın";
            ViewBag.Username = "Yalçın Yıldırım"; 
         // varsayılan olarak home ve ındex atandğımdan => localhost:5000/home/index =>home/index.cs
            return View();
        }
        /*
         //Course/Details/2 : route bağlı 
         //Course/Details?id=2 routa bağlı değil istediğimiz kadar parametre verebiliriz
         
        Metoda paramet olarak gelen değer adı pattern'deki isimle aynı olmak zorundadır.
        public ActionResult About(string id)
        {
            localhost:5000/home/about =>home/about.cs 
            return Content("gelen deger = "+id);
        } 
         */



        /*
         Bu kısım string query olarak geçer route'den bağımsızdır
         parametrelere verdiğin değerleri url kısmında belirmen gerek
         örnek : 
         home/about?id=10&ad=yalçın&soyad=yıldırım
         çıktısı : Ad =yalçınSoyad =yıldırımNumara =10

         public ActionResult About (int id, string ad,string soyad) {
            return Content("Ad ="+ad+"Soyad ="+soyad+"Numara ="+id);
        }
         
         */
        public ActionResult About(int id, string ad, string soyad)
        {
            return Content("Ad =" + ad + "Soyad =" + soyad + "Numara =" + id);
        }
    }
}

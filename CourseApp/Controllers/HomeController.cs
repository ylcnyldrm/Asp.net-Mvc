
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
            ViewBag.Greeting = saat > 12 ? "İyi günler" : "Günaydın";
            ViewBag.Username = "Yalçın Yıldırım";

            //localhost:5000/home/index =>home/index.cs
            return View();
        }
        public IActionResult About()
        {
            //localhost:5000/home/about =>home/about.cs
            return View();
        }
    }
}

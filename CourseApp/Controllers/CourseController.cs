using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace CourseApp.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index() 
        {
            //http://localhost:5000/course/index =>course/index.cs
            return View();
        }

        //http://localhost:5000/course/apply =>course/apply.cs
        public IActionResult Apply()
        {
            return View();
        }


        public IActionResult List()
        {
            //http://localhost:5000/course/list => course/list.cs
            return View();
        }
        public IActionResult Details()
        {   
            var course = new Course();
            course.Name = "Core Mvc Kursu";
            course.Desciription = "Güzel bir kurs";
            course.isPublished = true;

            //http://localhost:5000/course/deneme =>course/details.cs
            return View(course);
        }
    }
}

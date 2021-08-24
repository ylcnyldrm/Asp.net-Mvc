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
        //ilk sayfa açıldığında get çalışacak bize formu getiricek
        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }
        //kullancı submit butonuna tıkladıgında form ilgili adrese gidecek
        [HttpPost]
        public IActionResult Apply(Student student)
        {
            /*
              ModelState gelen modelin içerisindeki kurallara bakar ve kurallar doğru uygulanmışsa 
              IsVali true olur.
              Örnek Name kısmı boş değilse
            */ 
            if (ModelState.IsValid == true)
            {
                Repository.addStudent(student);
                //thanks view'ine git studenti gönder
                return View("Thanks", student);
            }
            else {
                return View(student);
            }
           
        }
        public IActionResult List()
        {
            var students = Repository.Student.Where(i=>i.Confirm==true);

            //http://localhost:5000/course/list => course/list.cs
            return View(students);
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

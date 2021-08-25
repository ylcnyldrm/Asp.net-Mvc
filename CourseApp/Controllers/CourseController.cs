using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Models;
using CourseApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace CourseApp.Controllers
{
    public class CourseController : Controller
    {
        //controllerden view'lere veri gönermek örneği (Viewdata,Viewbag,Model)
        //http://localhost:5000/course/index =>course/index.cs 

        //public IActionResult Index() 
        //{
        //    Course course = new Course();

        //    course.Name = "Asp.Net Mvc Kursu";
        //    course.Desciription = "Şuana kadar fena değil";
        //    course.isPublished = true;
        //    //verilerimizi course parametresiyle Viewdata ile gönderdik.
        //    //ViewData["course"] = course;

        //    //ViewBag.course = course;
        //    //ViewBag.count = 10; 
        //    return View(course);
        //}
        public IActionResult Index() {

            CourseInformation courseInformation = new CourseInformation() { Id=1,Name="Uygulamalı web geliştirme kursu"};
            List<Student> students = new List<Student>() {
             new Student() { Name = "ahmet" },
             new Student() { Name = "hasan" },
           };
            var viewModel = new CourseStudentsViewModel();
            viewModel.Course = courseInformation;
            viewModel.students = students;
            return View(viewModel);
        }


        public ActionResult Byreleased(int year,int month )
          {
            if (year==0 && month==0) {
                return Content("ay ve yıl alanları boş geldi");
            }
            return Content("year "+year+ "month"+month);
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
        public IActionResult Apply(StudentResponse student)
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

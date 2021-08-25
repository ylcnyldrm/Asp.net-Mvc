using CourseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.ViewModels
{
    public class CourseStudentsViewModel
    {
        public CourseInformation Course { get; set; }
        public List<Student> students { get; set; }
    }
}

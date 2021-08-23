using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public class Student
    { 
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public bool? Confirm { get; set; }  //true veya false gelebilir kullancı seçmezse null gelir 

    }
}

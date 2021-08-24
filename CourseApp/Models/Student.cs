using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public class Student
    {   
        [Required(ErrorMessage ="İsminizi giriniz")]
        public String Name { get; set; }

        [Required(ErrorMessage ="Email adresinizi giriniz")]
        [EmailAddress(ErrorMessage ="Email adresinizi formata uygun giriniz")] 
        public String Email { get; set; }
        [Required(ErrorMessage ="Telefon numaranızı giriniz")]
        public String Phone { get; set; }

        [Required(ErrorMessage ="Katılma durumunuz nedir ?")]
        public bool? Confirm { get; set; }  //true veya false gelebilir kullancı seçmezse null gelir 

    }
}

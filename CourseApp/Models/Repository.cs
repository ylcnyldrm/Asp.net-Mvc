using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public static class Repository
    {
        private static List<Student> _students = new List<Student>();
        public static List<Student> Student
        {
            get {

                return _students;
            }
        }

        public static void addStudent(Student student) 
        {
            _students.Add(student);
                }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public static class Repository
    {
        private static List<StudentResponse> _students = new List<StudentResponse>();
        public static List<StudentResponse> Student
        {
            get {

                return _students;
            }
        }

        public static void addStudent(StudentResponse student) 
        {
            _students.Add(student);
                }
    }
}

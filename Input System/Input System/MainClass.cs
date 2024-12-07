using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input_System
{
    internal class MainClass
    {
        public static List<Student> students = new List<Student>();
    }

    public class Student
    {
        public string firstName;
        public string middleName;
        public string lastName;
        public string collegeName;
        public string courseName;
        public string studentID;

        public Student(string firstName, string middleName, string lastName, string collegeName, string courseName, string id)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.collegeName = collegeName;
            this.courseName = courseName;
            this.studentID = id;
        }
    }
}

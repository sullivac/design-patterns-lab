using System.Collections.Generic;

namespace Lab
{
    public class StudentDatabase
    {
        private readonly List<Student> _students = new List<Student>
        {
            new Student
            {
                FirstName = "Tom",
                LastName = "Sites",
                UserId = "FRE",
                SemesterHours = 20,
                EmailAddress = "tsites@gmail.com"
            },
            new Student
            {
                FirstName = "Peggy",
                LastName = "Thompson",
                UserId = "SOP",
                SemesterHours = 40,
                EmailAddress = "peggy1218@aol.com"
            },
            new Student
            {
                FirstName = "Teresa",
                LastName = "Ramos",
                SemesterHours = 70,
                UserId = "JUN",
                EmailAddress = "tramos@gmail.com"
            },
            new Student
            {
                FirstName = "Jeffrey",
                LastName = "Belcher",
                SemesterHours = 120,
                UserId = "SEN",
                EmailAddress = "belcherisawesome@gmail.com"
            },
            new Student
            {
                FirstName = "Susan",
                LastName = "Belcher",
                SemesterHours = 120,
                UserId = "SEN2",
                EmailAddress = "belcher@foodnetwork.com"

            }
        };

        public IEnumerable<Student> Students
        {
            get { return _students; }
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }
    }
}
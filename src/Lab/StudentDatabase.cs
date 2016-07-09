using System.Collections.Generic;

namespace Lab
{
    public class StudentDatabase
    {
        private readonly Student[] _students =
        {
            new Student
            {
                FirstName = "Tom",
                LastName = "Sites",
                UserId = "FRE",
                SemesterHours = 20
            },
            new Student
            {
                FirstName = "Peggy",
                LastName = "Thompson",
                UserId = "SOP",
                SemesterHours = 40
            },
            new Student
            {
                FirstName = "Teresa",
                LastName = "Ramos",
                SemesterHours = 70,
                UserId = "JUN"
            },
            new Student
            {
                FirstName = "Jeffrey",
                LastName = "Belcher",
                SemesterHours = 120,
                UserId = "SEN"
            }
        };

        public IEnumerable<Student> Students
        {
            get { return _students; }
        }
    }
}
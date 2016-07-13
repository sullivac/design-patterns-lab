using System.Collections.Generic;

namespace Lab
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SemesterHours { get; set; }
        public string UserId { get; set; }
        public string EmailAdress { get; set; }

        private List<Course> _courses = new List<Course>();

        public void AddCourse(Course course)
        {
            _courses.Add(course);
        }
    }
}
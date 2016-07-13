using System.Collections.Generic;

namespace Lab
{
    public class CourseDatabase
    {
        private readonly Course[] _courses =
        {
            new Course
            {
                CourseLevel = 101,
                CourseName = "Hypertext Markup Language 1",
                CourseId = "HTML101"
            },
            new Course
            {
                CourseLevel = 151,
                CourseName = "Hypertext Markup Language 2",
                CourseId = "HTML151"
            },
            new Course
            {
                CourseLevel = 301,
                CourseName = "Cascading Style Sheets 1",
                CourseId = "CSS301"
            },
            new Course
            {
                CourseLevel = 401,
                CourseName = "Cascading Style Sheets 2",
                CourseId = "CSS401"
            },
            new Course
            {
                CourseLevel = 101,
                CourseName = "JavaScript 1",
                CourseId = "JS101"
            },
            new Course
            {
                CourseLevel = 201,
                CourseName = "JavaScript 2",
                CourseId = "JS201"
            },
            new Course
            {
                CourseLevel = 301,
                CourseName = "JavaScript 3",
                CourseId = "JS301"
            },
            new Course
            {
                CourseLevel = 401,
                CourseName = "JavaScript 4",
                CourseId = "JS401"
            },
            new Course
            {
                CourseLevel = 491,
                CourseName =  "Senior Project",
                CourseId = "SP491"
            }
        };

        public IEnumerable<Course> Courses
        {
            get
            {
                return _courses;
            }
        }
    }
}
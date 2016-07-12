using System;
using System.Linq;

namespace Lab
{
    //Freshman [0,32)
    //Sophmore [32,64)
    //Junior [64,96)
    //Senior [96,inf)

    internal class Program
    {
        private static void Main(string[] args)
        {
            StudentDatabase studentDatabase = new StudentDatabase();
            CourseDatabase courseDatabase = new CourseDatabase();

            //100 level courses
            Student freshman = studentDatabase.Students.FirstOrDefault(s => s.UserId == "FRE");
            if (freshman != null)
            {
                AddCourse(freshman, courseDatabase.Courses.SingleOrDefault(course => course.CourseId == "HTML101"));
                AddCourse(freshman, courseDatabase.Courses.SingleOrDefault(course => course.CourseId == "CSS301"));
            }

            //300 level courses
            Student junior = studentDatabase.Students.FirstOrDefault(s => s.UserId == "JUN");
            if (junior != null)
            {
                AddCourse(junior, courseDatabase.Courses.SingleOrDefault(course => course.CourseId == "HTML101"));
                AddCourse(junior, courseDatabase.Courses.SingleOrDefault(course => course.CourseId == "CSS401"));
            }

            //400 level courses
            Student senior = studentDatabase.Students.FirstOrDefault(s => s.UserId == "SEN");
            if (senior != null)
            {
                AddCourse(senior, courseDatabase.Courses.SingleOrDefault(course => course.CourseId == "CSS401"));
                AddCourse(senior, courseDatabase.Courses.SingleOrDefault(course => course.CourseId == "JS401"));
                AddCourse(senior, courseDatabase.Courses.SingleOrDefault(course => course.CourseId == "SP491"));

            }

            Student anotherSenior = studentDatabase.Students.FirstOrDefault(s => s.UserId == "SEN2");
            if (senior != null)
            {
                AddCourse(anotherSenior, courseDatabase.Courses.SingleOrDefault(course => course.CourseId == "CSS401"));
                AddCourse(anotherSenior, courseDatabase.Courses.SingleOrDefault(course => course.CourseId == "JS401"));
                AddCourse(anotherSenior, courseDatabase.Courses.SingleOrDefault(course => course.CourseId == "SP491"));
            }

            //junor
            studentDatabase.AddStudent(new Student
            {
                SemesterHours = 64,
                LastName = "Mapel",
                FirstName = "Robert",
                UserId = "RMAPLE"
            });

            studentDatabase.AddStudent(new Student
            {
                SemesterHours = 0,
                LastName = "Spruce",
                FirstName = "James",
                UserId = "JSPRUCE"
            });
        }

        public static void AddCourse(Student student, Course course)
        {
            bool isValid = true;
            int courseLevel = course.CourseLevel;
            int semesterHours = student.SemesterHours;

            if (courseLevel >= 200 && courseLevel < 300)
            {
                if (semesterHours < 32)
                {
                    Console.WriteLine("Need a sophmore standing");
                    isValid = false;
                }
            }
            else if (courseLevel >= 300 && courseLevel < 400)
            {
                if (semesterHours < 64)
                {
                    Console.WriteLine("Need a junior standing");
                    isValid = false;
                }
            }
            else
            {
                if (semesterHours < 96)
                {
                    Console.WriteLine("Need a senior standing");
                    isValid = false;
                }
            }

            if (isValid)
            {
                student.AddCourse(course);
            }
        }
    }
}
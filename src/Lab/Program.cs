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
                freshman.AddCourse(courseDatabase.Courses.SingleOrDefault(course => course.CourseId == "HTML101"));
                freshman.AddCourse(courseDatabase.Courses.SingleOrDefault(course => course.CourseId == "CSS301"));
            }

            //300 level courses
            Student junior = studentDatabase.Students.FirstOrDefault(s => s.UserId == "JUN");
            if (junior != null)
            {
                junior.AddCourse(courseDatabase.Courses.SingleOrDefault(course => course.CourseId == "HTML101"));
                junior.AddCourse(courseDatabase.Courses.SingleOrDefault(course => course.CourseId == "CSS401"));
            }

            //400 level courses
            Student senior = studentDatabase.Students.FirstOrDefault(s => s.UserId == "SEN");
            if (senior != null)
            {
                senior.AddCourse(courseDatabase.Courses.SingleOrDefault(course => course.CourseId == "HTML101"));
                senior.AddCourse(courseDatabase.Courses.SingleOrDefault(course => course.CourseId == "CSS401"));
            }
        }
    }
}
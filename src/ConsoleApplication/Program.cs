using System;
using System.Linq;
using System.Net;
using System.Net.Mail;

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
            Student robertMapel = new Student
            {
                SemesterHours = 64,
                LastName = "Mapel",
                FirstName = "Robert",
                UserId = "RMAPLE",
                EmailAdress = "bob.maple@gmail.com"
            };

            if (robertMapel.LastName.Length > 0 && robertMapel.FirstName.Length > 0)
            {
                studentDatabase.AddStudent(robertMapel);
                if (robertMapel.EmailAdress.Length > 0 && robertMapel.EmailAdress.Contains("@"))
                {
                    //The SMTP server isn't available. Can we create a class around this logic?
                    //using (SmtpClient smtpClient = new SmtpClient())
                    //{
                    //    smtpClient.Timeout = 3000;
                    //    smtpClient.Credentials = new NetworkCredential();
                    //    smtpClient.Send(
                    //        "registration@centareu.edu", 
                    //        robertMapel.EmailAddress, 
                    //        "Registration Complete",
                    //        "");
                    //}    
                }  
            }

           Student jamesSpruce = new Student
            {
                SemesterHours = 0,
                LastName = "Spruce",
                FirstName = "James",
                UserId = "JSPRUCE",
                EmailAdress = "james.spruce@yahoo.com"
            };
            if (jamesSpruce.LastName.Length > 0 && jamesSpruce.FirstName.Length > 0)
            {
                studentDatabase.AddStudent(jamesSpruce);
                if (jamesSpruce.EmailAdress.Length > 0 && jamesSpruce.EmailAdress.Contains("@"))
                {
                    //The SMTP server isn't available. Can we create a class around this logic?
                    //using (SmtpClient smtpClient = new SmtpClient())
                    //{
                    //    smtpClient.Timeout = 3000;
                    //    smtpClient.Credentials = new NetworkCredential();
                    //    smtpClient.Send(
                    //        "registration@centareu.edu", 
                    //        jamesSpruce.EmailAdress, 
                    //        "Registration Complete",
                    //        "");
                    //}    
                }  
            }
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
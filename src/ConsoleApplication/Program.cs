using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;

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

            InitializeMailSettings();

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
                EmailAddress = "bob.maple@gmail.com"
            };

            if (robertMapel.LastName.Length > 0 && robertMapel.FirstName.Length > 0)
            {
                studentDatabase.AddStudent(robertMapel);
                if (robertMapel.EmailAddress.Length > 0 && robertMapel.EmailAddress.Contains("@"))
                {
                    using (SmtpClient smtpClient = new SmtpClient())
                    {
                        smtpClient.Send(
                            "registration@centareu.edu",
                            robertMapel.EmailAddress,
                            "Registration Complete",
                            "");
                    }
                }
            }

            Student jamesSpruce = new Student
             {
                 SemesterHours = 0,
                 LastName = "Spruce",
                 FirstName = "James",
                 UserId = "JSPRUCE",
                 EmailAddress = "james.spruce@yahoo.com"
             };
            if (jamesSpruce.LastName.Length > 0 && jamesSpruce.FirstName.Length > 0)
            {
                studentDatabase.AddStudent(jamesSpruce);
                if (jamesSpruce.EmailAddress.Length > 0 && jamesSpruce.EmailAddress.Contains("@"))
                {
                    using (SmtpClient smtpClient = new SmtpClient())
                    {
                        smtpClient.Send(
                            "registration@centareu.edu",
                            jamesSpruce.EmailAddress,
                            "Registration Complete",
                            "");
                    }
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

        private static void InitializeMailSettings()
        {
            var mailPath = new DirectoryInfo("mail");
            if (!mailPath.Exists)
            {
                mailPath.Create();
            }

            BindingFlags instanceFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            PropertyInfo prop;
            object mailConfiguration, smtp, specifiedPickupDirectory;

            // get static internal property: MailConfiguration
            prop = typeof(SmtpClient).GetProperty("MailConfiguration", BindingFlags.Static | BindingFlags.NonPublic);
            mailConfiguration = prop.GetValue(null, null);

            // get internal property: Smtp
            prop = mailConfiguration.GetType().GetProperty("Smtp", instanceFlags);
            smtp = prop.GetValue(mailConfiguration, null);

            // get internal property: SpecifiedPickupDirectory
            prop = smtp.GetType().GetProperty("SpecifiedPickupDirectory", instanceFlags);
            specifiedPickupDirectory = prop.GetValue(smtp, null);

            // get private field: pickupDirectoryLocation, then set it to the supplied path
            FieldInfo field = specifiedPickupDirectory.GetType().GetField("pickupDirectoryLocation", instanceFlags);
            field.SetValue(specifiedPickupDirectory, mailPath.FullName);
        }
    }
}
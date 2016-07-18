using System;

namespace Lab
{
    class Validator
    {
        public bool Validate(Course course)
        {


            return false;
        }
    }



    class DefaultCourseValidatorFactory : ICreateCourseValidator
    {
        public IValidateCourse CreateValidator(Student student)
        {
            bool isValid = true;
            int courseLevel = course.CourseLevel;
            int semesterHours = student.SemesterHours;


            if (semesterHours < 32)
            {
                return new FreshmanCourseValidator();
            }

            throw new NotSupportedException();

            //else if (courseLevel >= 300 && courseLevel < 400)
            //{
            //    if (semesterHours < 64)
            //    {
            //        Console.WriteLine("Need a junior standing");
            //        isValid = false;
            //    }
            //}
            //else
            //{
            //    if (semesterHours < 96)
            //    {
            //        Console.WriteLine("Need a senior standing");
            //        isValid = false;
            //    }
            //}
        }
    }
}

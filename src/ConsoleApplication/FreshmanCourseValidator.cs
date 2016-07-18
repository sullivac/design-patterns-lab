using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class FreshmanCourseValidator : IValidateCourse
    {
        public bool Validate(Course course)
        {
            if (course.CourseLevel >= 200 && course.CourseLevel < 300)
            {
                return true;
            }

            return false;
        }
    }
}

namespace Lab
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SemesterHours { get; set; }
        public string UserId { get; set; }

        public void AddCourse(Course course)
        {
            bool isValid = true;
            int courseLevel = course.CourseLevel;

            if (courseLevel >= 200 && courseLevel < 300)
            {
                if (SemesterHours < 32)
                {
                    new Alert("Need a sophmore standing", "warning");
                    isValid = false;
                }
            }
            else if (courseLevel >= 300 && courseLevel < 400)
            {
                if (SemesterHours < 64)
                {
                    new Alert("Need a junior standing", "warning");
                    isValid = false;
                }
            }
            else
            {
                if (SemesterHours < 96)
                {
                    new Alert("Need a senior standing", "warning");
                    isValid = false;
                }
            }

            if (isValid)
            {
                
            }
        }
    }
}
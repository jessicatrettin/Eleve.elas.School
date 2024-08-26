using School.Model.Entities;

namespace School.Model.Dtos
{
    public class CourseDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual string TeacherName { get; set; }

        public CourseDto(Course course)
        {
            Id = course.Id;
            Title = course.Title;
            Description = course.Description;
            TeacherName = course.Teacher.Name;
        }
    }
}

namespace School.Model.Dtos
{
    public class TeacherDto : PersonDto
    {
        public ICollection<CourseDto> Courses { get; set; }
    }
}

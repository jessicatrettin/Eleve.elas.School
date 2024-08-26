namespace School.Model.Entities
{
    public class Teacher : Person
    {
        public ICollection<Course> Courses { get; set; }
    }
}

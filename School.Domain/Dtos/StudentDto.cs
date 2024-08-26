using School.Model.Entities;

namespace School.Model.Dtos
{
    public class StudentDto : PersonDto
    {
        public long Id { get; set; }
        public ICollection<EnrollmentDto> Enrollments { get; set; }
        public bool Active { get; set; }
        public virtual AddressDto Address { get; set; }

        public StudentDto(Student student)
        {
            Id = student.Id;
            Name = student.Name;
            Email = student.Email;
            Enrollments = student.Enrollments.Select(x => new EnrollmentDto(x)).ToList();
            Active = student.Active;
            Address = new AddressDto(student.Address);
        }
    }
}

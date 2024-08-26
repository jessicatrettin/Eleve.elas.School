using School.Model.Entities;

namespace School.Model.Dtos
{
    public class StudentCreateDto : PersonDto
    {
        public virtual AddressDto Address { get; set; }

        public StudentCreateDto(Student student)
        {
            Id = student.Id;
            Name = student.Name;
            Email = student.Email;
            Address = new AddressDto(student.Address);
        }
    }
}

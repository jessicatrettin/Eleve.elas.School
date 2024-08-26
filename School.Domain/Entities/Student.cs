using School.Model.Dtos;

namespace School.Model.Entities
{
    public class Student : Person
    {
        public ICollection<Enrollment> Enrollments { get; set; }
        public bool Active { get; set; }

        public long AddressId { get; set; }
        public virtual Address Address { get; set; }

        public Student(StudentCreateDto studentCreateDto)
        {
            Name = studentCreateDto.Name;
            Email = studentCreateDto.Email;
            Enrollments = new List<Enrollment>();
            Active = true;
            Address = new Address(studentCreateDto.Address);
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public void UpdateAddress(AddressDto addressDto)
        {
            Address.UpdateAddress(addressDto);
        }

        public void InactiveStudent()
        {
            Active = false;
        }
    }
}

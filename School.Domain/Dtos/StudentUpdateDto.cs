namespace School.Model.Dtos
{
    public class StudentUpdateDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public virtual AddressDto? Address { get; set; }
    }
}

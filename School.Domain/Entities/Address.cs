using School.Model.Dtos;
using School.Model.Entities.Enums;

namespace School.Model.Entities
{
    public class Address : BaseEntity
    {
        public string ZipCode { get; set; }
        public string AdressType { get; set; }
        public string AdressName { get; set; }
        public string Number { get; set; }
        public string? Complement { get; set; }
        public string City { get; set; }
        public State State { get; set; }

        public Student Student { get; set; }

        public Address(AddressDto addressDto)
        {
            ZipCode = addressDto.ZipCode;
            AdressType = addressDto.AdressType;
            AdressName = addressDto.AdressName;
            Number = addressDto.Number;
            Complement = addressDto.Complement;
            City = addressDto.City;
            State = addressDto.State;
        }

        public void UpdateAddress(AddressDto addressDto)
        {
            ZipCode = addressDto.ZipCode;
            AdressType = addressDto.AdressType;
            AdressName = addressDto.AdressName;
            Number = addressDto.Number;
            Complement = addressDto.Complement;
            City = addressDto.City;
            State = addressDto.State;
        }
    }
}

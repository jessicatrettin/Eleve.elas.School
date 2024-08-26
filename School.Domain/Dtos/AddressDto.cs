using School.Model.Entities;
using School.Model.Entities.Enums;

namespace School.Model.Dtos
{
    public class AddressDto : BaseDto
    {
        public string ZipCode { get; set; }
        public string AdressType { get; set; }
        public string AdressName { get; set; }
        public string Number { get; set; }
        public string? Complement { get; set; }
        public string City { get; set; }
        public State State { get; set; }

        public AddressDto(Address address)
        {
            Id = address.Id;
            ZipCode = address.ZipCode;
            AdressType = address.AdressType;
            AdressName = address.AdressName;
            Number = address.Number;
            Complement = address.Complement;
            City = address.City;
            State  = address.State;
        }
    }
}

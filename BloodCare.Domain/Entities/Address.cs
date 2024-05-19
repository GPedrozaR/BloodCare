using BloodCare.Domain.Base;

namespace BloodCare.Domain.Entities
{
    public class Address : BaseEntity
    {
        public Address(string street, string city, string state, string zipCode)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public Donor Donor { get; set; }
    }
}

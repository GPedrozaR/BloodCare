using BloodCare.Domain.Base;

namespace BloodCare.Domain.Entities
{
    internal class Donor : BaseEntity
    {
        public Donor(string fullName, string email, DateTime dateOfBirth, string gender, double weight, string bloodType, string rhFactor, List<Donation> donations)
        {
            FullName = fullName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Donations = donations;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public string BloodType { get; private set; }
        public string RhFactor { get; private set; }
        public List<Donation> Donations { get; private set; }
    }
}

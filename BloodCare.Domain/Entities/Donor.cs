using BloodCare.Domain.Base;
using BloodCare.Domain.Enums;

namespace BloodCare.Domain.Entities
{
    public class Donor : BaseEntity
    {
        public Donor(string fullName, string email, DateTime dateOfBirth, string cpf, string gender, double weight, BloodType bloodType, RhFactor rhFactor, Address address)
        {
            FullName = fullName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Cpf = cpf;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Address = address;

            CreatedAt = DateTime.Now;
            Situation = DonorSituation.Active;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public BloodType BloodType { get; private set; }

        public RhFactor RhFactor { get; private set; }

        public DonorSituation Situation { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Address Address { get; set; }

        public bool CanDonate()
        {
            var age = CalculateAge(DateOfBirth);
            if (age < 18)
                return false;

            if (Weight < 50.0)
                return false;

            return true;
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            var age = DateTime.Today.Year - dateOfBirth.Year;

            if (DateTime.Today < dateOfBirth.AddYears(age))
                age--;

            return age;
        }
    }
}

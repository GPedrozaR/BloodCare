using BloodCare.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodCare.Domain.Entities
{
    public class BloodStock : BaseEntity
    {
        public string BloodType { get; private set; }
        public string RhFactor { get; private set; }
        public int Milliliters { get; private set; }

        public BloodStock(string bloodType, string rhFactor, int milliliters)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            Milliliters = milliliters;
        }
    }
}

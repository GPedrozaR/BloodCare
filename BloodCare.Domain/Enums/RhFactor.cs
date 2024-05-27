using System.ComponentModel;

namespace BloodCare.Domain.Enums
{
    public enum RhFactor
    {
        [Description("Em Espera")]
        None = 0,

        [Description("Positivo")]
        Positive = 1,

        [Description("Negativo")]
        Negative = 2
    }
}

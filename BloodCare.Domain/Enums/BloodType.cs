using System.ComponentModel;

namespace BloodCare.Domain.Enums
{
    public enum BloodType
    {
        [Description("Em espera")]
        None = 0,

        [Description("Tipo A")]
        A = 1,

        [Description("Tipo B")]
        B = 2,

        [Description("Tipo AB")]
        AB = 3,

        [Description("Tipo O")]
        O = 4
    }
}

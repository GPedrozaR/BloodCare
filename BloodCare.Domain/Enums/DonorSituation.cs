using System.ComponentModel;

namespace BloodCare.Domain.Enums
{
    public enum DonorSituation
    {
        [Description("Em espera")]
        None = 0,

        [Description("Ativo")]
        Active = 1,

        [Description("Inativo")]
        Inactive = 2,

        [Description("Excluído")]
        Deleted = 3
    }
}

using System.ComponentModel.DataAnnotations;

namespace Posto.ApplicationCore.Enum
{
    public enum EnumNotaChamado : byte
    {
        [Display(Name = "Um")]
        Um = 1,

        [Display(Name = "Dois")]
        Dois = 2,

        [Display(Name = "Três")]
        Tres = 3,

        [Display(Name = "Quatro")]
        Quatro = 4,

        [Display(Name = "Cinco")]
        Cinco = 5
    }
}
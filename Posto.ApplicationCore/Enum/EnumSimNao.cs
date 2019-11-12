using System.ComponentModel.DataAnnotations;

namespace Posto.ApplicationCore.Enum
{
    public enum EnumSimNao : byte
    {
        /// <summary>
        /// MV2000
        /// </summary>
        [Display(Name = "Sim")]
        Sim = 1,

        /// <summary>
        /// SOULMV
        /// </summary>
        [Display(Name = "Não")]
        Nao = 2,
    }
}
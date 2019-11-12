using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Posto.ApplicationCore.Enum
{
    public enum EnumTipoSerie : byte
    {
        [Display(Name = "Simples")]
        Simples = 1,

        [Display(Name = "Dupla")]
        Dupla = 2,

        [Display(Name = "Dual")]
        Dual = 3,

        [Display(Name = "Kit Aéreo")]
        Kit_Aereo = 4,

        [Display(Name = "Quadrupla")]
        Quadrupla = 5,

        [Display(Name = "Sextupla")]
        Sextupla = 6,

    }
}

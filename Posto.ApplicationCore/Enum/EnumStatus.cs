using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Posto.ApplicationCore.Enum
{
    public enum EnumStatus : byte
    {
        [Display(Name = "Aberto")]
        Aberto = 1,

        [Display(Name = "Pendente")]
        Pendente = 2,

        [Display(Name = "Em Atendimento")]
        Em_Atendimento = 3,

        [Display(Name = "Encerrado")]
        Encerrado = 4
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Posto.ApplicationCore.Enum
{
    public enum EnumTipoImagem : byte
    {
        [Display(Name = "ClienteChamado")]
        ClienteChamado = 1,

        [Display(Name = "TecnicoResolucao")]
        TecnicoResolucao = 2
    }
}

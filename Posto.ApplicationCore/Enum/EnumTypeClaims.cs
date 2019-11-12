using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Posto.ApplicationCore.Enum
{
    public enum EnumTypeClaims : byte
    {
        [Display(Name = "Nome", Description = "Nome")]
        Nome = 1,

        [Display(Name = "Perfil", Description = "Perfil")]
        Perfil = 2,

        [Display(Name = "Id_Usuario", Description = "Id_Usuario")]
        Id_Usuario = 3,
    }
}

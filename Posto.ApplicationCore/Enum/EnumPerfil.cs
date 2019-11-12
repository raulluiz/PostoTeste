using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Posto.ApplicationCore.Enum
{
    public enum EnumPerfil : byte
    {
        [Display(Name = "Administrador", Description = "Administrador")]
        Administrador = 1,

        [Display(Name = "Terceirizada", Description = "Terceirizada")]
        Terceirizada = 2,

        [Display(Name = "Tecnico", Description = "Tecnico")]
        Tecnico = 3,

        [Display(Name = "Empresa", Description = "Empresa")]
        Empresa = 4,

        [Display(Name = "Cliente", Description = "Cliente")]
        Cliente = 5,

        [Display(Name = "Distribuidora", Description = "Distribuidora")]
        Distribuidora = 6
    }
}

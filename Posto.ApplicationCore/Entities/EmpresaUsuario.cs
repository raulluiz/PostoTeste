using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class EmpresaUsuario
    {
        public int Id_Usuario { get; set; }
        public int IdEmpresa { get; set; }

        public EmpresaUsuario(int Id_Usuario, int IdEmpresa)
        {
            this.IdEmpresa = IdEmpresa;
            this.Id_Usuario = Id_Usuario;
        }

        public Empresa Empresa { get; set; }
        public Usuario Usuario { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class Tecnico
    {
        public int Id_Tecnico { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Empresa { get; set; }
        public long Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime Programacao_Preventiva { get; set; }

        public Tecnico(int Id_Usuario, long Cpf, DateTime Programacao_Preventiva, int Id_Empresa)
        {
            this.Id_Usuario = Id_Usuario;
            this.Cpf = Cpf;
            this.Programacao_Preventiva = Programacao_Preventiva;
            this.Id_Empresa = Id_Empresa;
        }

        public Usuario Usuario { get; set; }
    }
}

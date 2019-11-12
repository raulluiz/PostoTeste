using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class Distribuidora
    {
        public int Id_Distribuidora { get; set; }
        [ForeignKey("Usuario")]
        public int Id_Usuario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Usuario Usuario { get; set; }

        public void AtualizarDistribuidora(string Nome, string Cpf, string Email, string Telefone)
        {
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.Email = Email;
            this.Telefone = Telefone;
        }
    }
}

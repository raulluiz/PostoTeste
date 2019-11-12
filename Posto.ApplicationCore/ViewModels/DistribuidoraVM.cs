using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.ViewModels
{
    public class DistribuidoraVM
    {
        public int Id_Distribuidora { get; set; }
        public int Id_Usuario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario Usuario { get; set; }
    }
}

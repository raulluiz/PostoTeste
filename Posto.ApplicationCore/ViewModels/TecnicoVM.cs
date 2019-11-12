using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.ViewModels
{
    public class TecnicoVM
    {
        public int Id_Tecnico { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Empresa { get; set; }
        public long Cpf { get; set; }
        public DateTime Programacao_Preventiva { get; set; }
        //Identity
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //Usuario
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        //Endereço
        public string Endereco_Complemento { get; set; }
        public string LinkGoogleMaps { get; set; }
    }
}

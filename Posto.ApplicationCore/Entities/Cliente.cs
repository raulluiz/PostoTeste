using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class Cliente
    {
        public int Id_Cliente { get; set; }
        public int Id_Usuario { get; set; }
        public long Cnpj { get; set; }
        public DateTime Data_Preventiva_Mes { get; set; }
        public string Razao_Social { get; set; }
        public DateTime Prazo_Cliente { get; set; }
        public int Programacao_Preventiva { get; set; }
        public int Id_Tecnico { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Nome { get; set; }

        public Cliente() { }

        public Usuario Usuario { get; set; }
    }
}

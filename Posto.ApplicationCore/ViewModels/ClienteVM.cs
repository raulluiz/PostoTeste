using Microsoft.AspNetCore.Mvc.Rendering;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Enum;
using System;
using System.Collections.Generic;

namespace Posto.ApplicationCore.ViewModels
{
    public class ClienteVM
    {
        public int Id_Cliente { get; set; }
        public int Id_Usuario { get; set; }
        public long Cnpj { get; set; }
        public DateTime Data_Preventiva_Mes { get; set; }
        public string Razao_Social { get; set; }
        public DateTime Prazo_Cliente { get; set; }
        public int Programacao_Preventiva { get; set; }
        //Identity
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //Usuario
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        //Endereço
        public string Endereco_Complemento { get; set; }
        public string LinkGoogleMaps { get; set; }
        public List<int> Series { get; set; }
        public string NomeCliente { get; set; }
    }

    //public class ClienteUsuarioVM : ClienteVM
    //{
    //    public string Nome { get; set; }
    //    public bool Ativo { get; set; }
    //    public string Cpf { get; set; }
    //    public string IdentityUser { get; set; }
    //    public EnumPerfil Perfil { get; set; }
    //}
}
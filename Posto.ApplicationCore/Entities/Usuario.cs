using Posto.ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string Cpf { get; set; }
        public string IdentityUser { get; set; }
        public EnumPerfil Perfil { get; set; }
        public int? Id_Endereco { get; set; }

        public Usuario( string Nome, bool Ativo, string Cpf, string IdentityUser, EnumPerfil Perfil)
        {
            this.Nome = Nome;
            this.Ativo = Ativo;
            this.Cpf = Cpf;
            this.IdentityUser = IdentityUser;
            this.Perfil = Perfil;

        }

        public Usuario(int Id_Usuario, string Nome, bool Ativo, string Cpf, string IdentityUser, EnumPerfil Perfil, int? Id_Endereco)
        {
            this.Nome = Nome;
            this.Ativo = Ativo;
            this.Cpf = Cpf;
            this.IdentityUser = IdentityUser;
            this.Perfil = Perfil;
            this.Id_Usuario = Id_Usuario;
            this.Id_Endereco = Id_Endereco;
        }

        public void Inativar()
        {
            this.Ativo = false;
        }

        public ICollection<EmpresaUsuario> EmpresaUsuarios { get; set; }
        public Endereco Endereco { get; set; }
    }
}

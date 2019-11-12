using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class Empresa
    {
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public long CNPJ { get; set; }
        public bool Ativo { get; set; }
        public string Razao { get; set; }

        public Empresa(int IdEmpresa, string Nome, long CNPJ, bool Ativo, string Razao)
        {
            this.Ativo = Ativo;
            this.CNPJ = CNPJ;
            this.IdEmpresa = IdEmpresa;
            this.Nome = Nome;
            this.Razao = Razao;
        }

        public void Inativar()
        {
            this.Ativo = false;
        }

        public ICollection<EmpresaUsuario> EmpresaUsuarios { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class Produto
    {
        public int Id_Produto { get; set; }
        public string Nome { get; set; }
        public int IdEmpresa { get; set; }
        public bool Ativo { get; set; }
        public int Id_Serie { get; set; }

        public Empresa Empresa { get; set; }

        public Produto(){ }

        public void Inativar()
        {
            this.Ativo = false;
        }
    }
}

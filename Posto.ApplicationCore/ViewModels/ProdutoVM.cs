using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.ViewModels
{
    public class ProdutoVM
    {
        public int Id_Produto { get; set; }
        public string Nome { get; set; }
        public int IdEmpresa { get; set; }
        public bool Ativo { get; set; }
        public int Id_Serie { get; set; }
    }
}

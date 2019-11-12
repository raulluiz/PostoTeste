using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.ViewModels
{
    public class EmpresaVM
    {
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public long CNPJ { get; set; }
        public bool Ativo { get; set; }
        public string Razao { get; set; }
    }
}

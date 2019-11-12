using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class Exemplo
    {
        public int ExemploId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public IList<ExemploItem> Itens { get; set; }
    }
}

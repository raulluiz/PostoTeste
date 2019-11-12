using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class ExemploItem
    {
        public int ExemploItemId { get; set; }
        public string Nome { get; set; }
        public Exemplo Exemplo { get; set; }
    }
}

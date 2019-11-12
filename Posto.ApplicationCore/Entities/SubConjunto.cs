using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class SubConjunto
    {
        [Key]
        public int Id_SubConjunto { get; set; }
        public string Nome { get; set; }
    }
}

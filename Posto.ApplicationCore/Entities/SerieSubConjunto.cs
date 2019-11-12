using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class SerieSubConjunto
    {
        public int Id_SubConjunto { get; set; }
        public int Id_Serie { get; set; }

        public SerieSubConjunto(int Id_Serie, int Id_SubConjunto)
        {
            this.Id_Serie = Id_Serie;
            this.Id_SubConjunto = Id_SubConjunto;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class ChamadoSubConjunto
    {
        public int Id_Chamado { get; set; }
        public int Id_SubConjunto { get; set; }

        public ChamadoSubConjunto(int Id_Chamado, int Id_SubConjunto)
        {
            this.Id_Chamado = Id_Chamado;
            this.Id_SubConjunto = Id_SubConjunto;
        }
    }
}

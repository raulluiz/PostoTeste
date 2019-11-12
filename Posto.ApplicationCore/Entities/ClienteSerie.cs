using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class ClienteSerie
    {
        public int Id_Cliente { get; set; }
        public int Id_Serie { get; set; }

        public ClienteSerie(int Id_Cliente, int Id_Serie)
        {
            this.Id_Cliente = Id_Cliente;
            this.Id_Serie = Id_Serie;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class Endereco
    {
        public int Id_Endereco { get; set; }
        public string Endereco_Complemento { get; set; }
        public string LinkGoogleMaps { get; set; }

        public Endereco(string Endereco_Complemento, string LinkGoogleMaps)
        {
            this.Endereco_Complemento = Endereco_Complemento;
            this.LinkGoogleMaps = LinkGoogleMaps;
        }

    }
}

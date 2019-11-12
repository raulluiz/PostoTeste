using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.ViewModels
{
    public class EnderecoVM
    {
        public int Id_Endereco { get; set; }
        public string Endereco_Complemento { get; set; }
        public string LinkGoogleMaps { get; set; }
        public int Id_Usuario { get; set; }
    }
}

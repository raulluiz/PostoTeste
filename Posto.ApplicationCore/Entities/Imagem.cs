using Posto.ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class Imagem
    {
        public int Id_Imagem { get; set; }
        public int Id_Usuario { get; set; }
        public byte[] ImagemByte { get; set; }
        public EnumTipoImagem Tipo { get; set; }

        public Imagem(int Id_Usuario, byte[] ImagemByte, EnumTipoImagem Tipo)
        {
            this.Id_Usuario = Id_Usuario;
            this.ImagemByte = ImagemByte;
            this.Tipo = Tipo;
        }
    }
}

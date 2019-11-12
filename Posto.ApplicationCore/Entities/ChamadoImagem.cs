using Posto.ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class ChamadoImagem
    {
        public int Id_Imagem { get; set; }
        public int Id_Chamado { get; set; }

        public ChamadoImagem (int Id_Chamado, int Id_Imagem)
        {
            this.Id_Chamado = Id_Chamado;
            this.Id_Imagem = Id_Imagem;
        }

    }
}

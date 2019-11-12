using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class ChamadoProduto
    {
        public int Id_Chamado { get; set; }
        public int Id_Produto { get; set; }

        public ChamadoProduto(int Id_Chamado, int Id_Produto)
        {
            this.Id_Chamado = Id_Chamado;
            this.Id_Produto = Id_Produto;
        }
    }
}

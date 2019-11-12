using Posto.ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.ViewModels
{
    public class ChamadoVM
    {
        public int Id_Chamado { get; set; }

        public int Id_Cliente { get; set; }
        public int? Id_Tecnico { get; set; }
        public int Id_Empresa { get; set; }
        public int Id_Serie { get; set; }

        public DateTime Data_Inicial { get; set; }
        public DateTime? Data_Prazo { get; set; }
        public DateTime? Data_Final { get; set; }
        public string Descricao_Problema_Cliente { get; set; }
        public string Defeito_Encontrado_Tecnico { get; set; }
        public EnumNotaChamado? Nota_Tempo { get; set; }
        public EnumNotaChamado? Nota_Tecnico { get; set; }
        public EnumNotaChamado? Nota_Eficacia { get; set; }
        public EnumStatus? Status { get; set; }
        public bool Corretiva { get; set; }

        //Tecnico
        public string Nome_Tecnico { get; set; }

        //Cliente
        public string Nome_Cliente { get; set; }
        //Serie
        public int Series { get; set; }

        public List<int> Produtos { get; set; }

        public List<int> SubConjuntos { get; set; }

        public List<int> SubConjuntosTecnico { get; set; }

    }
}

using Posto.ApplicationCore.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Posto.ApplicationCore.Entities
{
    public class Chamado
    {
        private string v;

        [Key]
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
        public string Nome_Cliente { get; set; }
        public string Nome_Tecnico { get; set; }
        public bool Corretiva { get; set; }
        public int Id_Equipamento { get; set; }

        public Chamado() { }

        public Chamado(int Id_Cliente, int? Id_Tecnico, int Id_Empresa, int Id_Serie, DateTime Data_Inicial, DateTime? Data_Prazo, DateTime? Data_Final, string Descricao_Problema_Cliente,
            string Defeito_Encontrado_Tecnico, EnumNotaChamado? Nota_Tempo, EnumNotaChamado? Nota_Tecnico, EnumNotaChamado? Nota_Eficacia, EnumStatus? Status, string Nome_Cliente, bool Corretiva)
        {
            this.Id_Cliente = Id_Cliente;
            this.Id_Tecnico = Id_Tecnico;
            this.Id_Empresa = Id_Empresa;
            this.Data_Inicial = Data_Inicial;
            this.Data_Prazo = Data_Prazo;
            this.Data_Final = Data_Final;
            this.Descricao_Problema_Cliente = Descricao_Problema_Cliente;
            this.Defeito_Encontrado_Tecnico = Defeito_Encontrado_Tecnico;
            this.Nota_Tempo = Nota_Tempo;
            this.Nota_Tecnico = Nota_Tecnico;
            this.Nota_Eficacia = Nota_Eficacia;
            this.Status = Status;
            this.Id_Serie = Id_Serie;
            this.Nome_Cliente = Nome_Cliente;
            this.Corretiva = Corretiva;
        }

        public Chamado(string v)
        {
            this.v = v;
        }

        public void AtualizarChamadoTecnico(int? Id_Tecnico, DateTime? Data_Final, string Defeito_Encontrado_Tecnico, EnumStatus? Status, string Nome_Tecnico)
        {
            this.Id_Tecnico = Id_Tecnico;
            this.Data_Final = Data_Final;
            this.Defeito_Encontrado_Tecnico = Defeito_Encontrado_Tecnico;
            this.Status = Status;
            this.Nome_Tecnico = Nome_Tecnico;
        }
    }
}
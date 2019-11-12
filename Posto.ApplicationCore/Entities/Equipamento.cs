using Posto.ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Posto.ApplicationCore.Entities
{
    public class Equipamento
    {
        [Key]
        public int Id_Equipamento { get; set; }
        public string Modelo_Bomba { get; set; }
        public EnumTipoSerie Tipo { get; set; }
        public string Numero_Serie { get; set; }
        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
        public bool Ativo { get; set; }

        public Equipamento(string Modelo_Bomba, EnumTipoSerie Tipo, string Numero_Serie, int IdEmpresa)
        {
            this.Modelo_Bomba = Modelo_Bomba;
            this.Tipo = Tipo;
            this.Numero_Serie = Numero_Serie;
            this.IdEmpresa = IdEmpresa;
        }

        public void Inativar()
        {
            this.Ativo = false;
        }

    }
}

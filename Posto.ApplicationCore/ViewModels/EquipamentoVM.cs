using Posto.ApplicationCore.Enum;

namespace Posto.ApplicationCore.ViewModels
{
    public class EquipamentoVM
    {
        public int Id_Equipamento { get; set; }
        public string Modelo_Bomba { get; set; }
        public EnumTipoSerie Tipo { get; set; }
        public string Numero_Serie { get; set; }
        public int IdEmpresa { get; set; }
        public bool Ativo { get; set; }
    }
}
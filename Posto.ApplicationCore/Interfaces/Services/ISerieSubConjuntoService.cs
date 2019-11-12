using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Interfaces.Services
{
    public interface ISerieSubConjuntoService : IBaseService<SerieSubConjunto>
    {
        List<Empresa> GetEmpresaPorAtivo(string nome);
        void SalvarEquipamentoSubConjunto(EquipamentoVM equipamentoVM);
        void UpdateEquipamentoSubConjunto(EquipamentoVM equipamentoVM);
        void RemoverEquipamentoSubConjunto(int id, int idEmpresa);
    }
}

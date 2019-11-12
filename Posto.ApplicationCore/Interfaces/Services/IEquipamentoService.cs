using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Interfaces.Services
{
    public interface IEquipamentoService : IBaseService<Equipamento>
    {
        //List<Empresa> GetEmpresaPorAtivo(string nome);
        void SalvarEquipamento(EquipamentoVM equipamentoVM);
        void UpdateEquipamento(EquipamentoVM equipamentoVM);
        void RemoverEquipamento(int id, int idEmpresa);
    }
}

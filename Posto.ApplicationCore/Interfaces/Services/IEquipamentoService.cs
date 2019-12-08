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
        string SalvarEquipamento(EquipamentoVM equipamentoVM);
        string UpdateEquipamento(EquipamentoVM equipamentoVM);
        string RemoverEquipamento(int id, int idEmpresa);
    }
}

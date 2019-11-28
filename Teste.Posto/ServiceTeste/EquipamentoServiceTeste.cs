using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto.ServiceTeste
{
    class EquipamentoServiceTeste : BaseService<Equipamento>, IEquipamentoService
    {
        public Equipamento Add(Equipamento entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipamento> Get(Expression<Func<Equipamento, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipamento> GetAll()
        {
            throw new NotImplementedException();
        }

        public Equipamento GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Equipamento entity)
        {
            throw new NotImplementedException();
        }

        public void RemoverEquipamento(int id, int idEmpresa)
        {
            throw new NotImplementedException();
        }

        public void SalvarEquipamento(EquipamentoVM equipamentoVM)
        {
            throw new NotImplementedException();
        }

        public void Update(Equipamento entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEquipamento(EquipamentoVM equipamentoVM)
        {
            throw new NotImplementedException();
        }
    }
}

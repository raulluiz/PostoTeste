using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto.ServiceTeste
{
    class SerieSubConjuntoServiceTeste : BaseService<SerieSubConjunto>, ISerieSubConjuntoService
    {
        public SerieSubConjunto Add(SerieSubConjunto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SerieSubConjunto> Get(Expression<Func<SerieSubConjunto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SerieSubConjunto> GetAll()
        {
            throw new NotImplementedException();
        }

        public SerieSubConjunto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Empresa> GetEmpresaPorAtivo(string nome)
        {
            throw new NotImplementedException();
        }

        public void Remove(SerieSubConjunto entity)
        {
            throw new NotImplementedException();
        }

        public void RemoverEquipamentoSubConjunto(int id, int idEmpresa)
        {
            throw new NotImplementedException();
        }

        public void SalvarEquipamentoSubConjunto(EquipamentoVM equipamentoVM)
        {
            throw new NotImplementedException();
        }

        public void Update(SerieSubConjunto entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEquipamentoSubConjunto(EquipamentoVM equipamentoVM)
        {
            throw new NotImplementedException();
        }
    }
}

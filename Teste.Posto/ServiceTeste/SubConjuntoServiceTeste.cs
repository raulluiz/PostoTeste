using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto.ServiceTeste
{
    class SubConjuntoServiceTeste : BaseService<SubConjunto>, ISubConjuntoService
    {
        public SubConjunto Add(SubConjunto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubConjunto> Get(Expression<Func<SubConjunto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubConjunto> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<SubConjuntoVM> GetAllSubConjuntoVMs(List<SerieSubConjunto> idsSubConjuntos)
        {
            throw new NotImplementedException();
        }

        public SubConjunto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(SubConjunto entity)
        {
            throw new NotImplementedException();
        }

        public void Update(SubConjunto entity)
        {
            throw new NotImplementedException();
        }
    }
}

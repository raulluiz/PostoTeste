using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto.ServiceTeste
{
    class ChamadoSubConjuntoServiceTeste : BaseService<ChamadoSubConjunto>, IChamadoSubConjuntoService
    {
        public ChamadoSubConjunto Add(ChamadoSubConjunto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChamadoSubConjunto> Get(Expression<Func<ChamadoSubConjunto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChamadoSubConjunto> GetAll()
        {
            throw new NotImplementedException();
        }

        public ChamadoSubConjunto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(ChamadoSubConjunto entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ChamadoSubConjunto entity)
        {
            throw new NotImplementedException();
        }
    }
}

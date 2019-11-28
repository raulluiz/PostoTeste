using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto.ServiceTeste
{
    class ExemploService : BaseService<Exemplo>, IExemploService
    {
        public Exemplo Add(Exemplo entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exemplo> Get(Expression<Func<Exemplo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exemplo> GetAll()
        {
            throw new NotImplementedException();
        }

        public Exemplo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Exemplo entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Exemplo entity)
        {
            throw new NotImplementedException();
        }
    }
}

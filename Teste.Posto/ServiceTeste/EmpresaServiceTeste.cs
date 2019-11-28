using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto.ServiceTeste
{
    class EmpresaServiceTeste : BaseService<Empresa>, IEmpresaService
    {
        public Empresa Add(Empresa entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Empresa> Get(Expression<Func<Empresa, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Empresa> GetAll()
        {
            throw new NotImplementedException();
        }

        public Empresa GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Empresa entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Empresa entity)
        {
            throw new NotImplementedException();
        }
    }
}

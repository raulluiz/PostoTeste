using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto.ServiceTeste
{
    class EnderecoServiceTeste : BaseService<Endereco>, IEnderecoService
    {
    
public Endereco Add(Endereco entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Endereco> Get(Expression<Func<Endereco, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Endereco> GetAll()
        {
            throw new NotImplementedException();
        }

        public Endereco GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Endereco entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Endereco entity)
        {
            throw new NotImplementedException();
        }
    }
}

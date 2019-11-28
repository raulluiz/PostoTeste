using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto.ServiceTeste
{
    class ChamadoProdutoServiceTeste : BaseService<ChamadoProduto>, IChamadoProdutoService
    {
        public ChamadoProduto Add(ChamadoProduto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChamadoProduto> Get(Expression<Func<ChamadoProduto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChamadoProduto> GetAll()
        {
            throw new NotImplementedException();
        }

        public ChamadoProduto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(ChamadoProduto entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ChamadoProduto entity)
        {
            throw new NotImplementedException();
        }
    }
}

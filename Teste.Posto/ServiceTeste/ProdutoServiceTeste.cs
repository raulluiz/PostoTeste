using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto.ServiceTeste
{
    class ProdutoServiceTeste : BaseService<Produto>, IProdutoService
    {
        public Produto Add(Produto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> Get(Expression<Func<Produto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Produto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Produto entity)
        {
            throw new NotImplementedException();
        }

        public void RemoverProduto(int idEmpresa, int id_Serie, int id_Produto)
        {
            throw new NotImplementedException();
        }

        public void SalvarProduto(ProdutoVM produtoVM)
        {
            throw new NotImplementedException();
        }

        public void Update(Produto entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduto(ProdutoVM produtoVM)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto.ServiceTeste
{
    class DistribuidoraServiceTeste : BaseService<Distribuidora>, IDistribuidoraService
    {
        public Distribuidora Add(Distribuidora entity)
        {
            throw new NotImplementedException();
        }

        public Distribuidora AddDistribuidora(DistribuidoraVM distribuidora)
        {
            throw new NotImplementedException();
        }

        public Usuario AddUsuarioDistribuidora(IdentityUser usuarioIdentity, DistribuidoraVM distribuidora, string empresa_Global)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Distribuidora> Get(Expression<Func<Distribuidora, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Distribuidora> GetAll()
        {
            throw new NotImplementedException();
        }

        public Distribuidora GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Distribuidora entity)
        {
            throw new NotImplementedException();
        }

        public void RemoverDistribuidora(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Distribuidora entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateDistribuidora(DistribuidoraVM obj)
        {
            throw new NotImplementedException();
        }
    }
}

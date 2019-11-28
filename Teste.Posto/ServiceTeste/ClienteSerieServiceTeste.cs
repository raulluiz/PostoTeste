using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto.ServiceTeste
{
    class ClienteSerieServiceTeste : BaseService<ClienteSerie>, IClienteSerieService
    {
        public ClienteSerie Add(ClienteSerie entity)
        {
            throw new NotImplementedException();
        }

        public void CadastroClienteSerie(int id_Cliente, List<int> series)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClienteSerie> Get(Expression<Func<ClienteSerie, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClienteSerie> GetAll()
        {
            throw new NotImplementedException();
        }

        public ClienteSerie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(ClienteSerie entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ClienteSerie entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateClienteSerie(int id_Cliente, List<int> series)
        {
            throw new NotImplementedException();
        }
    }
}

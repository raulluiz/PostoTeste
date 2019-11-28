using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto.ServiceTeste
{
    class ChamadoImagemServiceTeste : BaseService<ChamadoImagem>, IChamadoImagemService
    {
        public ChamadoImagem Add(ChamadoImagem entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChamadoImagem> Get(Expression<Func<ChamadoImagem, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChamadoImagem> GetAll()
        {
            throw new NotImplementedException();
        }

        public ChamadoImagem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(ChamadoImagem entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ChamadoImagem entity)
        {
            throw new NotImplementedException();
        }
    }
}

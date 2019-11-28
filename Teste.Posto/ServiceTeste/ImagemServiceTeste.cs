using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto.ServiceTeste
{
    class ImagemServiceTeste : BaseService<Imagem>, IImagemService
    {
        public Imagem Add(Imagem entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Imagem> Get(Expression<Func<Imagem, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Imagem> GetAll()
        {
            throw new NotImplementedException();
        }

        public Imagem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Imagem entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Imagem entity)
        {
            throw new NotImplementedException();
        }
    }
}

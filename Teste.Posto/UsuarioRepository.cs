using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto
{
    class UsuarioRepository : IUsuarioService, IBaseService<Usuario>
    {
        List<Usuario> lista = new List<Usuario>();
        public Usuario Add(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> Get(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return lista.ToArray();
        }

        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}

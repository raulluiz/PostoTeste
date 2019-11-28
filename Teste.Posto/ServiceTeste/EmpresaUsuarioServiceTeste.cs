using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto.ServiceTeste
{
    class EmpresaUsuarioServiceTeste : BaseService<EmpresaUsuario>, IEmpresaUsuarioService
    {
        public EmpresaUsuario Add(EmpresaUsuario entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmpresaUsuario> Get(Expression<Func<EmpresaUsuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmpresaUsuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public EmpresaUsuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(EmpresaUsuario entity)
        {
            throw new NotImplementedException();
        }

        public void Update(EmpresaUsuario entity)
        {
            throw new NotImplementedException();
        }
    }
}

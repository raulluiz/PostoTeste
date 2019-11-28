using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.Infrastructure.Context;
using Posto.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto
{
    class UsuarioRepositoryTeste : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepositoryTeste(PostoContext dbContext) : base(dbContext)
        {
        }
    }
}

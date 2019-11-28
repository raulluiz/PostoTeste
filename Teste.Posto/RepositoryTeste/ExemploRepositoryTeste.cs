using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.Infrastructure.Context;
using Posto.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Posto.RepositoryTeste
{
    class ExemploRepositoryTeste : BaseRepository<Exemplo>, IExemploRepository
    {
        protected ExemploRepositoryTeste(PostoContext dbContext) : base(dbContext)
        {
        }
    }
}

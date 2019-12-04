using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.Infrastructure.Context;
using Posto.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Posto.RepositoryTeste
{
    public class TecnicoRepositoryTeste : BaseRepository<Tecnico>, ITecnicoRepository
    {
        public TecnicoRepositoryTeste(PostoContext dbContext) : base(dbContext)
        {
        }
    }
}

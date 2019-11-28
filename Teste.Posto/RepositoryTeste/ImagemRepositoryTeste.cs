using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.Infrastructure.Context;
using Posto.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Posto.RepositoryTeste
{
    class ImagemRepositoryTeste : BaseRepository<Imagem>, IImagemRepository
    {
        protected ImagemRepositoryTeste(PostoContext dbContext) : base(dbContext)
        {
        }
    }
}

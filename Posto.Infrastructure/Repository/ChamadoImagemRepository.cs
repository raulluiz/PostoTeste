using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.Repository
{
    public class ChamadoImagemRepository : BaseRepository<ChamadoImagem>, IChamadoImagemRepository
    {
        public ChamadoImagemRepository(PostoContext dbContext) : base(dbContext)
        {

        }
    }
}

using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.Repository
{
    public class ChamadoSubConjuntoRepository : BaseRepository<ChamadoSubConjunto>, IChamadoSubConjuntoRepository
    {
        public ChamadoSubConjuntoRepository(PostoContext dbContext) : base(dbContext)
        {

        }
    }
}

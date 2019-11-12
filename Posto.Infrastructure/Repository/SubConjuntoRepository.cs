using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.Infrastructure.Context;

namespace Posto.Infrastructure.Repository
{
    public class SubConjuntoRepository : BaseRepository<SubConjunto>, ISubConjuntoRepository
    {
        public SubConjuntoRepository(PostoContext dbContext) : base(dbContext)
        {
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.Infrastructure.Context;
using System.Linq;

namespace Posto.Infrastructure.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(PostoContext dbContext) : base(dbContext)
        {
        }

        public override Usuario GetById(int id)
        {
            DbSet.Where(u => u.Id_Usuario == id).Include(u => u.Endereco);
            return base.GetById(id);
        }
    }
}
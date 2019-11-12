using Microsoft.EntityFrameworkCore;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.Infrastructure.Context;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Posto.Infrastructure.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(PostoContext dbContext) : base(dbContext)
        {
        }

        public override Cliente GetById(int id)
        {
            DbSet.Where(u => u.Id_Cliente== id).Include(u => u.Usuario);
            return base.GetById(id);
        }

        //public override IEnumerable<Cliente> GetAll()
        //{
        //    DbSet.All(c => c.Id_Cliente == c.Id_Cliente).Include(c => c.Usuario);
        //    return base.GetAll();
        //}

        //public IEnumerable<Cliente> GetAllIncludeUser()
        //{
        //    DbSet.All<Cliente>
        //}
    }
}
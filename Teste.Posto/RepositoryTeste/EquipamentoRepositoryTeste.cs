using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.Infrastructure.Context;
using Posto.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Posto.RepositoryTeste
{
    public class EquipamentoRepositoryTeste : BaseRepository<Equipamento>, IEquipamentoRepository
    {
        public  EquipamentoRepositoryTeste(PostoContext dbContext) : base(dbContext)
        {
        }
    }
}

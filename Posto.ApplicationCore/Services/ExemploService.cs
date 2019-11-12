using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Services
{
    public class ExemploService : BaseService<Exemplo>, IExemploService
    {
        private readonly IExemploRepository _exemploRepository;
        public ExemploService(IExemploRepository exemploRepository) : base(exemploRepository)
        {
            _exemploRepository = exemploRepository;
        }


    }
}

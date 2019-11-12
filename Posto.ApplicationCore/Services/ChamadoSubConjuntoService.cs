using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Services
{
    public class ChamadoSubConjuntoService : BaseService<ChamadoSubConjunto>, IChamadoSubConjuntoService
    {
        private readonly IChamadoSubConjuntoRepository _chamadoSubConjuntoRepository;
        private readonly ISerieSubConjuntoService _serieSubConjuntoService;
        public ChamadoSubConjuntoService(IChamadoSubConjuntoRepository chamadoSubConjuntoRepository, ISerieSubConjuntoService serieSubConjuntoService) 
            : base(chamadoSubConjuntoRepository)
        {
            _chamadoSubConjuntoRepository = chamadoSubConjuntoRepository;
            _serieSubConjuntoService = serieSubConjuntoService;
        }

    }
}

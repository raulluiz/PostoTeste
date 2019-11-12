using AutoMapper;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Services
{
    public class ChamadoProdutoService : BaseService<ChamadoProduto>, IChamadoProdutoService
    {
        private readonly IChamadoProdutoRepository _chamadoProdutoRepository;
        private readonly IChamadoSubConjuntoService _chamadoSubConjuntoService;
        private readonly ISerieSubConjuntoService _serieSubConjuntoService;
        private readonly IMapper _mapper;
        public ChamadoProdutoService(IChamadoProdutoRepository chamadoProdutoRepository, ISerieSubConjuntoService serieSubConjuntoService, IChamadoSubConjuntoService chamadoSubConjuntoService,
            IMapper mapper) 
            : base(chamadoProdutoRepository)
        {
            _chamadoProdutoRepository = chamadoProdutoRepository;
            _serieSubConjuntoService = serieSubConjuntoService;
            _chamadoSubConjuntoService = chamadoSubConjuntoService;
            _mapper = mapper;
        }

    }
}

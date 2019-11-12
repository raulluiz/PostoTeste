using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;

namespace Posto.Web.Controllers
{
    public class SubConjuntoController : Controller
    {

        private readonly ISerieSubConjuntoService _serieSubConjuntoService;
        private readonly ISubConjuntoService _subConjuntoService;
        private readonly IMapper _mapper;
        public SubConjuntoController(IMapper mapper, ISerieSubConjuntoService serieSubConjuntoService, ISubConjuntoService subConjuntoService)
        {
            _mapper = mapper;
            _serieSubConjuntoService = serieSubConjuntoService;
            _subConjuntoService = subConjuntoService;
        }

        [HttpGet]
        public JsonResult GetSubConjuntosBySerie(int id_Serie)
        {
            var idsSubConjuntos = _serieSubConjuntoService.GetAll().Where(ss => ss.Id_Serie == id_Serie).ToList();
            var subconjuntos = _subConjuntoService.GetAllSubConjuntoVMs(idsSubConjuntos);

            return Json(subconjuntos);
        }
    }
}
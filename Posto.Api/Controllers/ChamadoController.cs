using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Posto.ApplicationCore.Interfaces.Services;

namespace Posto.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ChamadoController : ControllerBase
    {
        private readonly IChamadoService _chamadoService;
        public ChamadoController(IChamadoService chamadoService)
        {
            _chamadoService = chamadoService;
        }

        [HttpGet]
        public IActionResult Get(int idUsuario, string perfil)
        {
            try
            {
                var chamados = _chamadoService.GetChamadosApp(idUsuario, perfil);
                return Ok(chamados);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
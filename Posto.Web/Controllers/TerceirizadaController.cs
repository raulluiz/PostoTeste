using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Posto.ApplicationCore.Enum;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;

namespace Posto.Web.Controllers
{
    public class TerceirizadaController : Controller
    {
        #region Injeção de Dependência
        private readonly IDistribuidoraService _distribuidoraService;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public TerceirizadaController(IDistribuidoraService distribuidoraService, IUsuarioService usuarioService, IMapper mapper, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _distribuidoraService = distribuidoraService;
            _usuarioService = usuarioService;
            _mapper = mapper;
            _userManager = userManager;

        }
        #endregion

        public IActionResult Index()
        {
            try
            {
                var terceirizada = _usuarioService.Get(u => u.Perfil == EnumPerfil.Terceirizada);
                List<UsuarioVM> usuarios = new List<UsuarioVM>();
                if(terceirizada != null)
                    usuarios = _mapper.Map<IEnumerable<UsuarioVM>>(terceirizada).ToList();

                return View(usuarios);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
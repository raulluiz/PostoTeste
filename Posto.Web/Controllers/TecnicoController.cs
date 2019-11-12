using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Posto.ApplicationCore.Enum;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using Posto.Web.Helpers;

namespace Posto.Web.Controllers
{
    public class TecnicoController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUsuarioService _usuarioService;
        private readonly IEmpresaUsuarioService _empresaUsuarioService;
        private readonly ITecnicoService _tecnicoService;
        private readonly IMapper _mapper;
        public TecnicoController(IEmpresaUsuarioService empresaUsuarioService, IMapper mapper, ITecnicoService tecnicoService, UserManager<IdentityUser> userManager, IUsuarioService usuarioService)
        {
            _empresaUsuarioService = empresaUsuarioService;
            _mapper = mapper;
            _tecnicoService = tecnicoService;
            _userManager = userManager;
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            var tecnicos = _tecnicoService.GetAll();
            var tecnicosVM = _mapper.Map<IEnumerable<TecnicoVM>>(tecnicos);
            var usuarios = _usuarioService.GetAll();

            foreach (var item in tecnicosVM)
            {
                var user = usuarios.FirstOrDefault(u => u.Id_Usuario == item.Id_Usuario);
                item.Nome = user.Nome;
                item.Ativo = user.Ativo;
            }
            ViewBag.Tecnicos = tecnicosVM.Where(c => c.Ativo == true);

            //ViewBag.Tecnicos
            return View();
        }

        public IActionResult NovoTecnico()
        {

            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> NovoTecnico(TecnicoVM tecnico)
        {
            try
            {
                string empresa_Global = Request.Cookies["empresa_global"];
                IdentityUser usuarioIdentity = CarregarIdentityUser(tecnico);
                var resultCreateIdentity = await _userManager.CreateAsync(usuarioIdentity, tecnico.Cpf.ToString());
                if (resultCreateIdentity.Succeeded)
                {
                    var userGetId = await _userManager.FindByNameAsync(tecnico.Cpf.ToString());
                    var enderecoCriado = _tecnicoService.AddEnderecoTecnico(tecnico);
                    var usuarioCriado = _tecnicoService.AddUsuarioTecnico(userGetId, tecnico, enderecoCriado.Id_Endereco, empresa_Global);

                    tecnico.Id_Usuario = usuarioCriado.Id_Usuario;
                    _tecnicoService.AddTecnico(tecnico);

                    var resultRole = await _userManager.AddClaimsAsync(usuarioIdentity, new Claim[] {
                        new Claim(EnumTypeClaims.Perfil.ToString(), EnumPerfil.Tecnico.ToString()),
                        new Claim(EnumTypeClaims.Nome.ToString(), tecnico.Nome),
                        new Claim(EnumTypeClaims.Id_Usuario.ToString(), usuarioCriado.Id_Usuario.ToString())
                    });
                    if (resultRole.Succeeded)
                    {
                        return Redirect("Index");
                    }

                    return View(tecnico);
                }

                return View(tecnico);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IdentityUser CarregarIdentityUser(TecnicoVM tecnico)
        {
            IdentityUser usuario = new IdentityUser();
            usuario.Email = tecnico.Email;
            usuario.UserName = tecnico.Cpf.ToString();
            usuario.PhoneNumber = tecnico.PhoneNumber;

            return usuario;
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var tecnico = _tecnicoService.GetTecnico(id);
                var usuario = _usuarioService.GetById(tecnico.Id_Usuario);
                var userIdentity = await _userManager.FindByIdAsync(usuario.IdentityUser);
                tecnico.Email = userIdentity.Email;
                tecnico.PhoneNumber = userIdentity.PhoneNumber;
            return View(tecnico);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        public async Task<JsonResult> Edit(TecnicoVM tecnico)
        {
            _tecnicoService.UpdateTecnico(tecnico);
            _tecnicoService.UpdateEndereco(tecnico);
            var usuario = _tecnicoService.UpdateUsuario(tecnico);
            var usuarioIdentity = await _userManager.FindByIdAsync(usuario.IdentityUser);
            usuarioIdentity.Email = tecnico.Email;
            usuarioIdentity.PhoneNumber = tecnico.PhoneNumber;
            var result = await _userManager.UpdateAsync(usuarioIdentity);
            if (result.Succeeded)
            {
                return Json("OKOKOK");
            }
            return Json("");
        }

        [HttpPost]
        public JsonResult Remove(int id)
        {
            _tecnicoService.RemoveTecnico(id);
            return Json("");
        }
    }
}
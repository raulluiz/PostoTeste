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

namespace Posto.Web.Controllers
{
    public class DistribuidoraController : Controller
    {
        private readonly IDistribuidoraService _distribuidoraService;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DistribuidoraController(IDistribuidoraService distribuidoraService, IUsuarioService usuarioService, IMapper mapper, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _distribuidoraService = distribuidoraService;
            _usuarioService = usuarioService;
            _mapper = mapper;
            _userManager = userManager;

        }

        public IActionResult Index()
        {
            var distribuidoras = _distribuidoraService.GetAll();
            var distribuidoraVM = _mapper.Map<IEnumerable<DistribuidoraVM>>(distribuidoras);
            var usuarios = _usuarioService.GetAll();
            List<DistribuidoraVM> lista = new List<DistribuidoraVM>();

            foreach (var item in distribuidoraVM)
            {
                item.Usuario = usuarios.FirstOrDefault(u => u.Id_Usuario == item.Id_Usuario && u.Ativo == true);
                if(item.Usuario != null)
                    lista.Add(item);
            }
            //ViewBag.Clientes = clientesVM.Where(c => c.Usuario.Ativo == true);

            return View(lista);
        }

        public IActionResult NovaDistribuidora()
        {

            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> NovaDistribuidora(DistribuidoraVM obj)
        {
            try
            {
                string empresa_Global = Request.Cookies["empresa_global"];
                IdentityUser usuarioIdentity = CarregarIdentityUser(obj);
                var resultCreateIdentity = await _userManager.CreateAsync(usuarioIdentity, obj.Senha).ConfigureAwait(true);
                if (resultCreateIdentity.Succeeded)
                {
                    var userGetId = await _userManager.FindByNameAsync(obj.Login).ConfigureAwait(true);
                    //var enderecoCriado = _clienteService.AddEnderecoCliente(cliente);
                    var usuarioCriado = _distribuidoraService.AddUsuarioDistribuidora(userGetId, obj, empresa_Global);

                    obj.Id_Usuario = usuarioCriado.Id_Usuario;
                    var clienteEntidade = _distribuidoraService.AddDistribuidora(obj);

                    var resultRole = await _userManager.AddClaimsAsync(usuarioIdentity, new Claim[] {
                        new Claim(EnumTypeClaims.Perfil.ToString(), EnumPerfil.Distribuidora.ToString()),
                        new Claim(EnumTypeClaims.Nome.ToString(), obj.Nome),
                        new Claim(EnumTypeClaims.Id_Usuario.ToString(), usuarioCriado.Id_Usuario.ToString())
                    }).ConfigureAwait(true);
                    if (resultRole.Succeeded)
                    {
                        return Redirect("Index");
                    }

                    return View(obj);
                }

                return View(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IdentityUser CarregarIdentityUser(DistribuidoraVM distribuidora)
        {
            IdentityUser usuario = new IdentityUser();
            usuario.Email = distribuidora.Email;
            usuario.UserName = distribuidora.Login.ToString();
            usuario.PhoneNumber = distribuidora.Telefone;

            return usuario;
        }

        public IActionResult Edit(int id)
        {
            var empresa_Global = Convert.ToInt32(Request.Cookies["empresa_global"]);
            var distribuidora = _distribuidoraService.GetById(id);
            var distribuidoraVM = _mapper.Map<DistribuidoraVM>(distribuidora);

            return View(distribuidoraVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DistribuidoraVM obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            try
            {
                var usuario = _usuarioService.GetById(obj.Id_Usuario);
                var user = await _userManager.FindByIdAsync(usuario.IdentityUser);
                user.Email = obj.Email;
                user.UserName = obj.Cpf;
                user.PhoneNumber = obj.Telefone;
                var result = await _userManager.UpdateAsync(user);
                if(result.Succeeded)
                {
                    _distribuidoraService.UpdateDistribuidora(obj);
                }

               
                return Redirect("Index");
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        public JsonResult Remover(int id)
        {
            try
            {
                _distribuidoraService.RemoverDistribuidora(id);
                return Json("Distribuidora Removida com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
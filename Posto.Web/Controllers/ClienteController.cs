using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Posto.ApplicationCore.Enum;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using Posto.Web.Helpers;

namespace Posto.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUsuarioService _usuarioService;
        private readonly IEmpresaUsuarioService _empresaUsuarioService;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        private readonly IEquipamentoService _equipamentoService;
        private readonly IClienteSerieService _clienteSerieService;
        public ClienteController(IEmpresaUsuarioService empresaUsuarioService, IMapper mapper, IClienteService clienteService, UserManager<IdentityUser> userManager, IUsuarioService usuarioService,
            IEquipamentoService equipamentoService, IClienteSerieService clienteSerieService, RoleManager<IdentityRole> roleManager)
        {
            _empresaUsuarioService = empresaUsuarioService;
            _mapper = mapper;
            _clienteService = clienteService;
            _userManager = userManager;
            _usuarioService = usuarioService;
            _equipamentoService = equipamentoService;
            _clienteSerieService = clienteSerieService;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var clientes = _clienteService.GetAll();
            var clientesVM = _mapper.Map<IEnumerable<ClienteVM>>(clientes);
            var usuarios = _usuarioService.GetAll();

            foreach (var item in clientesVM)
            {
                var user = usuarios.FirstOrDefault(u => u.Id_Usuario == item.Id_Usuario);
                item.Nome = user.Nome;
                item.Ativo = user.Ativo;
            }
            ViewBag.Clientes = clientesVM.Where(c => c.Ativo == true);

            return View();
        }

        public IActionResult NovoCliente()
        {
            var empresa_Global = Convert.ToInt32(Request.Cookies["empresa_global"]);

            ViewBag.Series = _equipamentoService.Get(s => s.IdEmpresa == empresa_Global).Select(s => new SelectListItem()
            { Text = s.Modelo_Bomba, Value = s.Id_Equipamento.ToString() }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoCliente(ClienteVM cliente)
        {
            try
            {
                string empresa_Global = Request.Cookies["empresa_global"];
                IdentityUser usuarioIdentity = CarregarIdentityUser(cliente);
                var resultCreateIdentity = await _userManager.CreateAsync(usuarioIdentity,cliente.Cnpj.ToString());
                if (resultCreateIdentity.Succeeded)
                {
                    var userGetId = await _userManager.FindByNameAsync(cliente.Cnpj.ToString());
                    var enderecoCriado = _clienteService.AddEnderecoCliente(cliente);
                    var usuarioCriado = _clienteService.AddUsuarioCliente(userGetId, cliente, enderecoCriado.Id_Endereco, empresa_Global);

                    cliente.Id_Usuario = usuarioCriado.Id_Usuario;
                    var clienteEntidade = _clienteService.AddCliente(cliente);
                    _clienteSerieService.CadastroClienteSerie(clienteEntidade.Id_Cliente, cliente.Series);

                    var resultRole = await _userManager.AddClaimsAsync(usuarioIdentity, new Claim[] {
                        new Claim(EnumTypeClaims.Perfil.ToString(), EnumPerfil.Cliente.ToString()),
                        new Claim(EnumTypeClaims.Nome.ToString(), cliente.Nome),
                        new Claim(EnumTypeClaims.Id_Usuario.ToString(), usuarioCriado.Id_Usuario.ToString())
                    });
                    if (resultRole.Succeeded)
                    {
                        return Redirect("Index");
                    }

                    return View(cliente);
                }

                return View(cliente);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IdentityUser CarregarIdentityUser(ClienteVM cliente)
        {
            IdentityUser usuario = new IdentityUser();
            usuario.Email = cliente.Email;
            usuario.UserName = cliente.Cnpj.ToString();
            usuario.PhoneNumber = cliente.PhoneNumber;

            return usuario;
        }

        public IActionResult Edit(int id)
        {
            var empresa_Global = Convert.ToInt32(Request.Cookies["empresa_global"]);
            var cliente = _clienteService.GetCliente(id);

            ViewBag.Series = _equipamentoService.Get(s => s.IdEmpresa == empresa_Global).Select(s => new SelectListItem()
            { Text = s.Modelo_Bomba, Value = s.Id_Equipamento.ToString() }).ToList();

            return View(cliente);
        }

        [HttpPost]
        public async Task<JsonResult> Edit(ClienteVM cliente)
        {
            _clienteService.UpdateCliente(cliente);
            _clienteService.UpdateEndereco(cliente);
            var user = _clienteService.UpdateUsuario(cliente);

            _clienteSerieService.UpdateClienteSerie(cliente.Id_Cliente, cliente.Series);

            var usuarioIdentity = await _userManager.FindByIdAsync(user.IdentityUser);
            usuarioIdentity.PhoneNumber = cliente.PhoneNumber;
            usuarioIdentity.Email = cliente.Email;
            var result = await _userManager.UpdateAsync(usuarioIdentity);
            if (result.Succeeded)
            {
                return Json("OK OK OK");
            }

            return Json("");
        }

        [HttpPost]
        public JsonResult Remove(int id)
        {
            _clienteService.RemoveCliente(id);
            return Json("");
        }

        [HttpGet]
        public JsonResult GetClienteSeries(int id)
        {
            var series = _clienteSerieService.Get(s => s.Id_Cliente == id);
            return Json(series);
        }
    }
}
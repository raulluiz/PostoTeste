using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Enum;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using Posto.Web.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace Posto.Web.Controllers
{
    public class ChamadoController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IChamadoService _chamadoService;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        private readonly IEquipamentoService _serieService;
        private readonly IClienteSerieService _clienteSerieService;
        private readonly ISerieSubConjuntoService _serieSubConjuntoService;
        private readonly ISubConjuntoService _subConjuntoService;
        private readonly ITecnicoService _tecnicoService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmpresaUsuarioService _empresaUsuarioService;

        public ChamadoController(IChamadoService chamadoService, IMapper mapper, IClienteService clienteService, IUsuarioService usuarioService, UserManager<IdentityUser> userManager,
            IEquipamentoService serieService, IClienteSerieService clienteSerieService, ISerieSubConjuntoService serieSubConjuntoService, ISubConjuntoService subConjuntoService, ITecnicoService tecnicoService,
            IEmpresaUsuarioService empresaUsuarioService)
        {
            _chamadoService = chamadoService;
            _mapper = mapper;
            _clienteService = clienteService;
            _usuarioService = usuarioService;
            _serieService = serieService;
            _clienteSerieService = clienteSerieService;
            _serieSubConjuntoService = serieSubConjuntoService;
            _subConjuntoService = subConjuntoService;
            _userManager = userManager;
            _tecnicoService = tecnicoService;
            _empresaUsuarioService = empresaUsuarioService;
        }

        public IActionResult Index()
        {
            try
            {
                
                var empresa_Global = Convert.ToInt32(Request.Cookies["empresa_global"]);
                //var cliente = _clienteService.Get(c => c.)
                var perfil = User.Claims.FirstOrDefault(c => c.Type == "Perfil");

                IEnumerable<Chamado> chamadosEntidade = null;

                if (perfil != null && (perfil.Value == EnumPerfil.Administrador.ToString() || perfil.Value == EnumPerfil.Distribuidora.ToString()))
                    chamadosEntidade = _chamadoService.GetAll().Where(c => c.Id_Empresa == empresa_Global);
                else if (perfil != null && perfil.Value == EnumPerfil.Cliente.ToString())
                {
                    var id_usuario = User.Claims.FirstOrDefault(cl => cl.Type == EnumTypeClaims.Id_Usuario.ToString());
                    var cliente = _clienteService.Get(c => c.Id_Usuario == Convert.ToInt32(id_usuario.Value)).FirstOrDefault();
                    if(cliente != null)
                        chamadosEntidade = _chamadoService.GetAll().Where(c => c.Id_Empresa == empresa_Global && c.Id_Cliente == cliente.Id_Cliente);
                }
                else if (perfil != null && perfil.Value == EnumPerfil.Tecnico.ToString())
                {
                    var id_usuario = User.Claims.FirstOrDefault(cl => cl.Type == EnumTypeClaims.Id_Usuario.ToString());
                    var tecnico = _tecnicoService.Get(c => c.Id_Usuario == Convert.ToInt32(id_usuario.Value)).FirstOrDefault();
                    if(tecnico != null)
                        chamadosEntidade = _chamadoService.GetAll().Where(c => c.Id_Empresa == empresa_Global && c.Id_Tecnico == tecnico.Id_Tecnico);
                }

                List<ChamadoVM> chamados = new List<ChamadoVM>();
                if(chamadosEntidade != null)
                    chamados = _mapper.Map<IEnumerable<ChamadoVM>>(chamadosEntidade).ToList();

                return View(chamados);
            }
            catch (Exception e)
            {
                return View(e);
                throw;
            }
        }

        public IActionResult NovoChamado()
        {
            try
            {
                var empresa_Global = Convert.ToInt32(Request.Cookies["empresa_global"]);
                ViewBag.Series = _chamadoService.GetAllSeries(empresa_Global);

                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult NovoChamado(ChamadoVM chamado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var empresa_Global = Convert.ToInt32(Request.Cookies["empresa_global"]);
                    var idUsuario = _userManager.GetUserId(User);
                    var usuario = _usuarioService.Get(u => u.IdentityUser == idUsuario).FirstOrDefault();
                    chamado.Corretiva = true;

                    chamado.Id_Empresa = empresa_Global;
                    var chamadoEntidade = _chamadoService.SalvarChamado(chamado, usuario.Id_Usuario);
                    
                    var files = HttpContext.Request.Form.Files;
                    if (files.Count != 0)
                    {
                        foreach (var item in files)
                        {
                            var target = new MemoryStream();
                            var stream = item.OpenReadStream();
                            stream.CopyTo(target);
                            var data = target.ToArray();

                            _chamadoService.SalvarImagensCliente(chamadoEntidade, data, usuario.Id_Usuario);
                        }
                    }
                    return Redirect("Index");
                }
                
                return View(chamado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult FinalizarChamado(int id_chamado)
        {
            try
            {
                var empresa_Global = Convert.ToInt32(Request.Cookies["empresa_global"]);
                var chamadoVM = _mapper.Map<ChamadoVM>(_chamadoService.GetById(id_chamado));

                ViewBag.SeriesCliente = _chamadoService.GetAllSeries(empresa_Global);
                ViewBag.SubConjuntosCliente = _chamadoService.GetSubConjuntosChamado(chamadoVM);
                ViewBag.ProdutosCliente = _chamadoService.GetProdutosChamado(chamadoVM);
                ViewBag.ImagensCliente = _chamadoService.GetAllImagesChamado(chamadoVM.Id_Chamado);

                ViewBag.SubConjuntoTecnico = _chamadoService.GetAllSubConjuntos(chamadoVM.Id_Serie);
                

                return View(chamadoVM);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult FinalizarChamado(ChamadoVM chamado)
        {
            try
            {
                var empresa_Global = Convert.ToInt32(Request.Cookies["empresa_global"]);

                var files = HttpContext.Request.Form.Files;
                var id_usuario = User.Claims.FirstOrDefault(c => c.Type == EnumTypeClaims.Id_Usuario.ToString());
                _chamadoService.SalvarChamadoTecnico(files, chamado, Convert.ToInt32(id_usuario.Value));

                return Redirect("Index");
            }
            catch (Exception)
            {

                throw;
            }            
        }

        [HttpPost]
        public JsonResult Remove(int id)
        {
            try
            {

                return Json("");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public JsonResult GetAllTecnicos()
        {
            try
            {
                var empresa_Global = Convert.ToInt32(Request.Cookies["empresa_global"]);

                var tecnicos = _chamadoService.GetAllTecnicos(empresa_Global);

                return Json(tecnicos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public JsonResult SalvarTecnico(int id_Tecnico, int id_Chamado)
        {
            try
            {
                _chamadoService.AdicionarTecnicoChamado(id_Tecnico, id_Chamado);
                return Json("Técnico salvo com sucesso!");
            }
            catch (Exception ex)
            {
                return Json(ex.Message + " Favor entrar em contato com o administrador.");
            }
            
        }
    }
}
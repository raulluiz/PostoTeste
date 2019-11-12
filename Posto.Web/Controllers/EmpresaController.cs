using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;

namespace Posto.Web.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUsuarioService _usuarioService;
        private readonly IEmpresaUsuarioService _empresaUsuarioService;
        private readonly IEmpresaService _empresaService;
        private readonly IMapper _mapper;
        public EmpresaController(IEmpresaUsuarioService empresaUsuarioService, IMapper mapper, IEmpresaService empresaService, UserManager<IdentityUser> userManager, IUsuarioService usuarioService)
        {
            _empresaUsuarioService = empresaUsuarioService;
            _mapper = mapper;
            _empresaService = empresaService;
            _userManager = userManager;
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            ViewBag.Empresas = _mapper.Map<IEnumerable<EmpresaVM>>(_empresaService.Get(u => u.Ativo == true));
            return View();
        }

        public IActionResult NovaEmpresa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NovaEmpresa(EmpresaVM empresa)
        {
            var empresaEntity = _mapper.Map<Empresa>(empresa);
            _empresaService.Add(empresaEntity);
            ViewBag.message = "Empresa cadastrada com sucesso!";
            return RedirectToAction("Index");
        }

        public IActionResult EditarEmpresa(int id)
        {
            var empresa = _mapper.Map<EmpresaVM>( _empresaService.GetById(id));
            return View(empresa);
        }

        [HttpPost]
        public IActionResult EditarEmpresa(EmpresaVM empresa)
        {
            var empresaEntity = _empresaService.GetById(empresa.IdEmpresa);
            empresaEntity.Ativo = empresa.Ativo;
            empresaEntity.CNPJ = empresa.CNPJ;
            empresaEntity.Nome = empresa.Nome;
            empresaEntity.Razao = empresa.Razao;
            _empresaService.Update(empresaEntity);

            ViewBag.mensagem = "Empresa alterada com sucesso!";
            return View();
        }

        [HttpPost]
        public JsonResult RemoverEmpresa(int id)
        {
            var empresaEntity = _empresaService.GetById(id);
            empresaEntity.Inativar();
            _empresaService.Update(empresaEntity);
            return Json("Empresa removida com sucesso!");
        }

        [HttpGet]
        public async Task<JsonResult> GetByUser()
        {
            var usuario = await _userManager.FindByNameAsync(User.Identity.Name);
            var usuarioEntidade = _usuarioService.Get(u => u.IdentityUser == usuario.Id).FirstOrDefault(u => u.IdentityUser == usuario.Id);
            var usuariosEmpresas = _empresaUsuarioService.Get(ue => ue.Id_Usuario == usuarioEntidade.Id_Usuario);
            var empresas = _empresaService.GetAll();
            
            List<ComboSelect2VM> combo = new List<ComboSelect2VM>();
            foreach (var uEmpresa in usuariosEmpresas)
            {
                ComboSelect2VM item = new ComboSelect2VM();
                item.id = uEmpresa.IdEmpresa.ToString();
                var nome = empresas.FirstOrDefault(e => e.IdEmpresa == uEmpresa.IdEmpresa);
                if(nome != null)
                {
                    item.text = nome.Nome;
                    combo.Add(item);
                }
            }

            return Json(combo);
        }
    }
}
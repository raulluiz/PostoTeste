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
    public class EquipamentoController : Controller
    {
        #region Injeção de Dependência
        private readonly IUsuarioService _usuarioService;
        private readonly IEmpresaUsuarioService _empresaUsuarioService;
        private readonly IEquipamentoService _equipamentoService;
        private readonly IMapper _mapper;
        public EquipamentoController(IEmpresaUsuarioService empresaUsuarioService, IMapper mapper, IEquipamentoService equipamentoService, IUsuarioService usuarioService)
        {
            _empresaUsuarioService = empresaUsuarioService;
            _mapper = mapper;
            _equipamentoService = equipamentoService;
            _usuarioService = usuarioService;
        }

        #endregion

        public IActionResult Index()
        {
            try
            {
                string empresa_Global = Request.Cookies["empresa_global"];
                var equipamentoVM = _equipamentoService.GetAll().Where(s => s.IdEmpresa == Convert.ToInt32(empresa_Global) && s.Ativo == true);
                List<EquipamentoVM> equipamentos = new List<EquipamentoVM>();
                if(equipamentoVM != null)
                    equipamentos = _mapper.Map<IEnumerable<EquipamentoVM>>(equipamentoVM).ToList();
                return View(equipamentos);
            }
            catch (Exception)
            {
                return View();
                throw;
            }

        }

        public IActionResult NovoEquipamento()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NovoEquipamento(EquipamentoVM equipamento)
        {
            try
            {
                string empresa_Global = Request.Cookies["empresa_global"];
                equipamento.IdEmpresa = Convert.ToInt32(empresa_Global);
                equipamento.Ativo = true;
                _equipamentoService.SalvarEquipamento(equipamento);
                return Redirect("Index");
            }
            catch (Exception)
            {
                return View();
                throw;
            }

        }

        public IActionResult Edit(int id)
        {
            try
            {
                var empresa_Global = Convert.ToInt32(Request.Cookies["empresa_global"]);
                var serie = _equipamentoService.Get(s => s.Id_Equipamento == id && s.IdEmpresa == empresa_Global).FirstOrDefault();
                var serieVM = _mapper.Map<EquipamentoVM>(serie);
                return View(serieVM);
            }
            catch (Exception)
            {
                return View();
                throw;
            }

        }

        [HttpPost]
        public IActionResult Edit(EquipamentoVM equipamento)
        {
            try
            {
                _equipamentoService.UpdateEquipamento(equipamento);
                return Redirect("Index");
            }
            catch (Exception)
            {
                return View();
                throw;
            }

        }

        [HttpPost]
        public JsonResult Remove(int id)
        {
            try
            {
                var empresa_Global = Convert.ToInt32(Request.Cookies["empresa_global"]);
                _equipamentoService.RemoverEquipamento(id, empresa_Global);
                return Json("Removido com sucesso!");
            }
            catch (Exception ex)
            {
                return Json(ex);
                throw;
            }

        }

    }
}
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
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly IUsuarioService _usuarioService;
        private readonly IEmpresaUsuarioService _empresaUsuarioService;
        private readonly IEquipamentoService _equipamentoService;
        private readonly IMapper _mapper;
        public ProdutoController(IProdutoService produtoService, IEmpresaUsuarioService empresaUsuarioService, IMapper mapper, IEquipamentoService equipamentoService, IUsuarioService usuarioService)
        {
            _empresaUsuarioService = empresaUsuarioService;
            _mapper = mapper;
            _equipamentoService = equipamentoService;
            _usuarioService = usuarioService;
            _produtoService = produtoService;
        }

        public IActionResult Index(int id)
        {
            try
            {
                string empresa_Global = Request.Cookies["empresa_global"];
                var produtos = _produtoService.Get(p => p.IdEmpresa == Convert.ToInt32(empresa_Global) && p.Ativo == true && p.Id_Serie == id);
                ViewBag.Produtos = _mapper.Map<IEnumerable<ProdutoVM>>(produtos);
                return View();
            }
            catch (Exception)
            {
                return View();
                throw;
            }

        }

        public IActionResult NovoProduto(int id_serie)
        {
            ProdutoVM produto = new ProdutoVM();
            produto.Id_Serie = id_serie;
            return View(produto);
        }

        [HttpPost]
        public IActionResult NovoProduto(ProdutoVM produto)
        {
            try
            {
                string empresa_Global = Request.Cookies["empresa_global"];
                produto.IdEmpresa = Convert.ToInt32(empresa_Global);
                produto.Ativo = true;
                _produtoService.SalvarProduto(produto);
                return Redirect("View");
            }
            catch (Exception)
            {
                return View();
                throw;
            }

        }

        public IActionResult Edit(int id_Produto, int id_Serie)
        {
            try
            {
                var empresa_Global = Convert.ToInt32(Request.Cookies["empresa_global"]);
                var produto = _produtoService.Get(s => s.Id_Produto == id_Produto && s.IdEmpresa == empresa_Global && s.Id_Serie == id_Serie).FirstOrDefault();
                var produtoVM = _mapper.Map<ProdutoVM>(produto);
                return View(produtoVM);
            }
            catch (Exception)
            {
                return View();
                throw;
            }

        }

        [HttpPost]
        public IActionResult Edit(ProdutoVM produtoVM)
        {
            try
            {
                _produtoService.UpdateProduto(produtoVM);
                return Redirect("View");
            }
            catch (Exception)
            {
                return View();
                throw;
            }

        }

        [HttpPost]
        public JsonResult Remove(int id_Produto, int id_Serie)
        {
            try
            {
                var empresa_Global = Convert.ToInt32(Request.Cookies["empresa_global"]);
                _produtoService.RemoverProduto(empresa_Global, id_Serie, id_Produto);
                return Json("Removido com sucesso!");
            }
            catch (Exception ex)
            {
                return Json(ex);
                throw;
            }

        }

        [HttpGet]
        public JsonResult GetProdutosBySerie(int id_Serie)
        {
            try
            {
                var empresa_Global = Convert.ToInt32(Request.Cookies["empresa_global"]);
                var produtos = _produtoService.Get(p => p.Id_Serie == id_Serie && p.IdEmpresa == empresa_Global);

                return Json(produtos);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
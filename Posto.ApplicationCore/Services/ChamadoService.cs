using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Enum;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;

namespace Posto.ApplicationCore.Services
{
    public class ChamadoService : BaseService<Chamado>, IChamadoService
    {
        private readonly IChamadoRepository _chamadoRepository;
        private readonly IChamadoSubConjuntoService _chamadoSubConjuntoService;
        private readonly IChamadoProdutoService _chamadoProdutoService;
        private readonly IMapper _mapper;
        private readonly IChamadoImagemService _chamadoImagemService;
        private readonly IImagemService _imagemService;
        private readonly IClienteService _clienteService;
        private readonly ITecnicoService _tecnicoService;
        private readonly ISubConjuntoService _subConjuntoService;
        private readonly IEquipamentoService _serieService;
        private readonly IProdutoService _produtoService;
        private readonly ISerieSubConjuntoService _serieSubConjuntoService;
        private readonly IUsuarioService _usuarioService;
        private readonly IEmpresaUsuarioService _empresaUsuarioService;

        public ChamadoService(IChamadoRepository chamadoRepository, IChamadoSubConjuntoService chamadoSubConjuntoService, IMapper mapper, IClienteService clienteService,
            IChamadoProdutoService chamadoProdutoService, IChamadoImagemService chamadoImagemService, IImagemService imagemService, ITecnicoService tecnicoService, ISubConjuntoService subConjuntoService,
            IEquipamentoService serieService, IProdutoService produtoService, ISerieSubConjuntoService serieSubConjuntoService, IUsuarioService usuarioService, IEmpresaUsuarioService empresaUsuarioService) 
            : base(chamadoRepository)
        {
            _chamadoRepository = chamadoRepository;
            _chamadoProdutoService = chamadoProdutoService;
            _chamadoSubConjuntoService = chamadoSubConjuntoService;
            _mapper = mapper;
            _chamadoImagemService = chamadoImagemService;
            _imagemService = imagemService;
            _clienteService = clienteService;
            _tecnicoService = tecnicoService;
            _subConjuntoService = subConjuntoService;
            _serieService = serieService;
            _produtoService = produtoService;
            _serieSubConjuntoService = serieSubConjuntoService;
            _usuarioService = usuarioService;
            _empresaUsuarioService = empresaUsuarioService;
        }

        public Chamado SalvarChamado(ChamadoVM chamado, int id_Usuario)
        {
            try
            {
                var cliente = _clienteService.Get(c => c.Id_Usuario == id_Usuario).FirstOrDefault();
                if(cliente != null)
                {
                    chamado.Id_Cliente = cliente.Id_Cliente;
                    chamado.Nome_Cliente = cliente.Nome;
                }
                chamado.Data_Inicial = DateTime.Now;
                chamado.Status = EnumStatus.Aberto;
                var chamadoEntidade = _chamadoRepository.Add(_mapper.Map<Chamado>(chamado));

                foreach (var item in chamado.SubConjuntos)
                {
                    var chamadoSubConjunto = new ChamadoSubConjunto(chamadoEntidade.Id_Chamado, item);
                    _chamadoSubConjuntoService.Add(chamadoSubConjunto);
                }

                foreach (var item in chamado.Produtos)
                {
                    var chamadoProduto = new ChamadoProduto(chamadoEntidade.Id_Chamado, item);
                    _chamadoProdutoService.Add(chamadoProduto);
                }


                return chamadoEntidade;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SalvarImagensCliente(Chamado chamado, byte[] imagem, int Id_Usuario)
        {
            try
            {
                var imagemEntidade = new Imagem(Id_Usuario, imagem, EnumTipoImagem.ClienteChamado);
                var imagemEntidadeCriada = _imagemService.Add(imagemEntidade);
                var chamadoImagem = new ChamadoImagem(chamado.Id_Chamado, imagemEntidadeCriada.Id_Imagem);
                _chamadoImagemService.Add(chamadoImagem);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AdicionarTecnicoChamado(int id_Tecnico, int id_Chamado)
        {
            try
            {
                var chamado = _chamadoRepository.GetById(id_Chamado);
                var tecnico = _tecnicoService.GetById(id_Tecnico);
                chamado.Id_Tecnico = id_Tecnico;
                chamado.Nome_Tecnico = tecnico.Nome;
                _chamadoRepository.Update(chamado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SelectListItem> GetAllTecnicos(int id_empresa)
        {
            try
            {
                var tecnicos = _tecnicoService.Get(s => s.Id_Empresa == id_empresa).Select(s => new SelectListItem()
                { Text = s.Nome.ToString(), Value = s.Id_Tecnico.ToString() }).ToList();

                return tecnicos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SelectListItem> GetSubConjuntosChamado(ChamadoVM chamado)
        {
            try
            {
                var subConjuntosChamado = _chamadoSubConjuntoService.Get(s => s.Id_Chamado == chamado.Id_Chamado);

                List<SubConjunto> subConjuntos = new List<SubConjunto>();

                foreach (var item in subConjuntosChamado)
                {
                    var sub = _subConjuntoService.Get(s => s.Id_SubConjunto == item.Id_SubConjunto).FirstOrDefault();
                    if (sub != null)
                        subConjuntos.Add(sub);
                }

                var subConjuntosListItem = subConjuntos.Select(s => new SelectListItem()
                { Text = s.Nome.ToString(), Value = s.Id_SubConjunto.ToString(), Disabled = true, Selected = true }).ToList();

                return subConjuntosListItem;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SelectListItem> GetProdutosChamado(ChamadoVM chamado)
        {
            try
            {
                var produtosChamado = _chamadoProdutoService.Get(s => s.Id_Chamado == chamado.Id_Chamado);

                List<Produto> produtos = new List<Produto>();

                foreach (var item in produtosChamado)
                {
                    var prod = _produtoService.Get(s => s.Id_Produto == item.Id_Produto).FirstOrDefault();
                    if (prod != null)
                        produtos.Add(prod);
                }

                var produtosListItem = produtos.Select(s => new SelectListItem()
                { Text = s.Nome.ToString(), Value = s.Id_Produto.ToString(), Disabled = true, Selected = true }).ToList();

                return produtosListItem;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SelectListItem> GetAllSeries(int id_empresa)
        {
            try
            {
                var series = _serieService.Get(s => s.IdEmpresa == id_empresa).Select(s => new SelectListItem()
                {
                    Text = s.Modelo_Bomba,
                    Value = s.Id_Equipamento.ToString()
                }).ToList();

                return series;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<SelectListItem> GetAllSubConjuntos(int id_serie)
        {
            try
            {
                List<SubConjunto> subConjuntos = new List<SubConjunto>();

                var serieSubConjuntos = _serieSubConjuntoService.Get(ss => ss.Id_Serie == id_serie);

                foreach (var item in serieSubConjuntos)
                {
                    var sub = _subConjuntoService.Get(s => s.Id_SubConjunto == item.Id_SubConjunto).FirstOrDefault();
                    if (sub != null)
                        subConjuntos.Add(sub);
                }

                var subConjuntosListItem = subConjuntos.Select(s => new SelectListItem()
                { Text = s.Nome.ToString(), Value = s.Id_SubConjunto.ToString() }).ToList();

                return subConjuntosListItem;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<string> GetAllImagesChamado(int id_chamado)
        {
            try
            {
                List<Imagem> imagens = new List<Imagem>();
                var chamadoimagens = _chamadoImagemService.Get(ci => ci.Id_Chamado == id_chamado);

                foreach (var item in chamadoimagens)
                {
                    var imagem = _imagemService.Get(i => i.Id_Imagem == item.Id_Imagem).FirstOrDefault();
                    if (imagem != null)
                        imagens.Add(imagem);
                }

                List<string> imagensBlob = new List<string>();

                foreach (var item in imagens)
                {
                    string base64String = Convert.ToBase64String(item.ImagemByte);

                    imagensBlob.Add(base64String);
                }

                return imagensBlob;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void SalvarChamadoTecnico(IFormFileCollection files, ChamadoVM chamadoVM, int id_usuario)
        {
            try
            {
                var tecnico = _tecnicoService.Get(c => c.Id_Usuario == id_usuario).FirstOrDefault();
                var chamadoEntidade = _chamadoRepository.GetById(chamadoVM.Id_Chamado);
                chamadoEntidade.AtualizarChamadoTecnico(tecnico.Id_Tecnico, DateTime.Now, chamadoVM.Defeito_Encontrado_Tecnico, EnumStatus.Encerrado, tecnico.Nome);
                _chamadoRepository.Update(chamadoEntidade);
                

                if (files.Count != 0)
                {
                    foreach (var item in files)
                    {
                        var target = new MemoryStream();
                        var stream = item.OpenReadStream();
                        stream.CopyTo(target);
                        var data = target.ToArray();

                        var imagemEntidade = new Imagem(tecnico.Id_Usuario, data, EnumTipoImagem.TecnicoResolucao);
                        var imagemEntidadeCriada = _imagemService.Add(imagemEntidade);
                        var chamadoImagem = new ChamadoImagem(chamadoVM.Id_Chamado, imagemEntidadeCriada.Id_Imagem);
                        _chamadoImagemService.Add(chamadoImagem);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<ChamadoVM> GetChamadosApp(int idUsuario, string perfil)
        {
            IEnumerable<Chamado> chamadosEntidade = null;

            var usuario = _usuarioService.GetById(idUsuario);
            var empresaUsuario = _empresaUsuarioService.Get(eu => eu.Id_Usuario == idUsuario).FirstOrDefault();
            if (perfil == EnumPerfil.Cliente.ToString())
            {
                var cliente = _clienteService.Get(c => c.Id_Usuario == Convert.ToInt32(idUsuario)).FirstOrDefault();
                chamadosEntidade = _chamadoRepository.GetAll().Where(c => c.Id_Empresa == empresaUsuario.IdEmpresa && c.Id_Cliente == cliente.Id_Cliente);
            }
            
            //var cliente = _clienteService.Get(c => c.)
            //var perfil = User.Claims.FirstOrDefault(c => c.Type == "Perfil");

            

            //if (perfil != null && (perfil.Value == EnumPerfil.Administrador.ToString() || perfil.Value == EnumPerfil.Empresa.ToString()))
            //    chamadosEntidade = _chamadoService.GetAll().Where(c => c.Id_Empresa == empresa_Global);
            //else if (perfil != null && perfil.Value == EnumPerfil.Cliente.ToString())
            //{
            //    var id_usuario = User.Claims.FirstOrDefault(cl => cl.Type == EnumTypeClaims.Id_Usuario.ToString());
            //    var cliente = _clienteService.Get(c => c.Id_Usuario == Convert.ToInt32(id_usuario.Value)).FirstOrDefault();
            //    chamadosEntidade = _chamadoService.GetAll().Where(c => c.Id_Empresa == empresa_Global && c.Id_Cliente == cliente.Id_Cliente);
            //}
            //else if (perfil != null && perfil.Value == EnumPerfil.Tecnico.ToString())
            //{
            //    var id_usuario = User.Claims.FirstOrDefault(cl => cl.Type == EnumTypeClaims.Id_Usuario.ToString());
            //    var tecnico = _tecnicoService.Get(c => c.Id_Usuario == Convert.ToInt32(id_usuario.Value)).FirstOrDefault();
            //    chamadosEntidade = _chamadoService.GetAll().Where(c => c.Id_Empresa == empresa_Global && c.Id_Tecnico == tecnico.Id_Tecnico);
            //}


            var chamados = _mapper.Map<IEnumerable<ChamadoVM>>(chamadosEntidade);

            return chamados;
        }


    }
}

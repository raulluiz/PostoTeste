using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Enum;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Services
{
    public class TecnicoService : BaseService<Tecnico>, ITecnicoService
    {
        private readonly ITecnicoRepository _tecnicoRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IEnderecoService _enderecoService;
        private readonly IMapper _mapper;
        private readonly IEmpresaUsuarioService _empresaUsuarioService;
        public TecnicoService(ITecnicoRepository tecnicoRepository, IUsuarioService usuarioService, IEnderecoService enderecoService, IMapper mapper, IEmpresaUsuarioService empresaUsuarioService) 
            : base(tecnicoRepository)
        {
            _tecnicoRepository = tecnicoRepository;
            _usuarioService = usuarioService;
            _enderecoService = enderecoService;
            _empresaUsuarioService = empresaUsuarioService;
            _mapper = mapper;
        }

        //public List<Empresa> GetEmpresaPorAtivo(string nome)
        //{
        //    throw new NotImplementedException();
        //}

        public void AddTecnico(TecnicoVM tecnico)
        {
            try
            {
                Tecnico tecnicoEntidade = _mapper.Map<Tecnico>(tecnico);
                _tecnicoRepository.Add(tecnicoEntidade);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Endereco AddEnderecoTecnico(TecnicoVM tecnico)
        {
            try
            {
                Endereco endereco = new Endereco(tecnico.Endereco_Complemento, tecnico.LinkGoogleMaps);
                var enderecoEntidade = _enderecoService.Add(endereco);

                return enderecoEntidade;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Usuario AddUsuarioTecnico(IdentityUser usuarioIdentity, TecnicoVM tecnico, int id_Endereco, string empresa_Global)
        {
            try
            {
                Usuario usuario = new Usuario(tecnico.Nome, true, tecnico.Cpf.ToString(), usuarioIdentity.Id, EnumPerfil.Tecnico);
                usuario.Id_Endereco = id_Endereco;
                var usuariocriado = _usuarioService.Add(usuario);

                EmpresaUsuario empresaUsuario = new EmpresaUsuario(usuariocriado.Id_Usuario, Convert.ToInt32(empresa_Global));
                _empresaUsuarioService.Add(empresaUsuario);

                return usuariocriado;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public TecnicoVM GetTecnico(int id)
        {
            var tecnico = _tecnicoRepository.GetById(id);
            var tecnicoVM = _mapper.Map<TecnicoVM>(tecnico);
            var usuario = _usuarioService.GetById(tecnico.Id_Usuario);
            if (usuario.Id_Endereco.HasValue)
            {
                var endereco = _enderecoService.GetById(usuario.Id_Endereco.Value);
                tecnicoVM.Endereco_Complemento = endereco.Endereco_Complemento;
                tecnicoVM.LinkGoogleMaps = endereco.LinkGoogleMaps;
            }

            tecnicoVM.Ativo = usuario.Ativo;
            tecnicoVM.Nome = usuario.Nome;

            //var endereco = _enderecoService.GetById(clienteVM.id)

            return tecnicoVM;
        }

        public void UpdateTecnico(TecnicoVM tecnico)
        {
            var tecnicoEntidade = _mapper.Map<Tecnico>(tecnico);
            _tecnicoRepository.Update(tecnicoEntidade);
        }

        public void UpdateEndereco(TecnicoVM tecnico)
        {
            var usuario = _usuarioService.GetById(tecnico.Id_Usuario);
            if (usuario.Id_Endereco.HasValue)
            {
                var endereco = _enderecoService.GetById(usuario.Id_Endereco.Value);
                endereco.Endereco_Complemento = tecnico.Endereco_Complemento;
                endereco.LinkGoogleMaps = tecnico.LinkGoogleMaps;
                _enderecoService.Update(endereco);
            }
        }

        public Usuario UpdateUsuario(TecnicoVM tecnico)
        {
            var usuario = _usuarioService.GetById(tecnico.Id_Usuario);
            usuario.Nome = tecnico.Nome;
            _usuarioService.Update(usuario);

            return usuario;
        }

        public void RemoveTecnico(int id)
        {
            var tecnico = _tecnicoRepository.GetById(id);
            var usuario = _usuarioService.GetById(tecnico.Id_Usuario);
            usuario.Inativar();
            _usuarioService.Update(usuario);
        }
    }
}

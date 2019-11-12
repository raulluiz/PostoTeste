using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Enum;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using System;

namespace Posto.ApplicationCore.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IEnderecoService _enderecoService;
        private readonly IMapper _mapper;
        private readonly IEmpresaUsuarioService _empresaUsuarioService;

        public ClienteService(IClienteRepository clienteRepository, IUsuarioService usuarioService, IEnderecoService enderecoService, IMapper mapper, IEmpresaUsuarioService empresaUsuarioService) 
            : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
            _usuarioService = usuarioService;
            _enderecoService = enderecoService;
            _empresaUsuarioService = empresaUsuarioService;
            _mapper = mapper;
        }

        public Cliente AddCliente(ClienteVM cliente)
        {
            try
            {
                Cliente clienteEntidade = _mapper.Map<Cliente>(cliente);
                var clienteEntidade2 = _clienteRepository.Add(clienteEntidade);

                return clienteEntidade2;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Endereco AddEnderecoCliente(ClienteVM cliente)
        {
            try
            {
                Endereco endereco = new Endereco(cliente.Endereco_Complemento, cliente.LinkGoogleMaps);
                var enderecoEntidade = _enderecoService.Add(endereco);

                return enderecoEntidade;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Usuario AddUsuarioCliente(IdentityUser usuarioIdentity, ClienteVM cliente, int id_Endereco, string empresa_Global)
        {
            try
            {
                Usuario usuario = new Usuario(cliente.Nome,true,cliente.Cnpj.ToString(),usuarioIdentity.Id,EnumPerfil.Cliente);
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

        public ClienteVM GetCliente(int id)
        {
            var cliente = _clienteRepository.GetById(id);
            var clienteVM = _mapper.Map<ClienteVM>(cliente);
            var usuario = _usuarioService.GetById(cliente.Id_Usuario);
            if (usuario.Id_Endereco.HasValue)
            {
                var endereco = _enderecoService.GetById(usuario.Id_Endereco.Value);
                clienteVM.Endereco_Complemento = endereco.Endereco_Complemento;
                clienteVM.LinkGoogleMaps = endereco.LinkGoogleMaps;
            }
            
            clienteVM.Ativo = usuario.Ativo;
            clienteVM.Nome = usuario.Nome;
            
            //var endereco = _enderecoService.GetById(clienteVM.id)

            return clienteVM;
        }

        public void RemoveCliente(int id)
        {
            var cliente = _clienteRepository.GetById(id);
            var usuario = _usuarioService.GetById(cliente.Id_Usuario);
            usuario.Inativar();
            _usuarioService.Update(usuario);
        }

        public void UpdateCliente(ClienteVM cliente)
        {
            var clienteEntidade = _mapper.Map<Cliente>(cliente);
            _clienteRepository.Update(clienteEntidade);
        }

        public void UpdateEndereco(ClienteVM cliente)
        {
            var usuario = _usuarioService.GetById(cliente.Id_Usuario);
            if(usuario.Id_Endereco.HasValue)
            {
                var endereco = _enderecoService.GetById(usuario.Id_Endereco.Value);
                endereco.Endereco_Complemento = cliente.Endereco_Complemento;
                endereco.LinkGoogleMaps = cliente.LinkGoogleMaps;
                _enderecoService.Update(endereco);
            }
        }

        public Usuario UpdateUsuario(ClienteVM cliente)
        {
            var usuario = _usuarioService.GetById(cliente.Id_Usuario);
            usuario.Nome = cliente.Nome;
            _usuarioService.Update(usuario);

            return usuario;
        }

        //public List<Empresa> GetEmpresaPorAtivo(string nome)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
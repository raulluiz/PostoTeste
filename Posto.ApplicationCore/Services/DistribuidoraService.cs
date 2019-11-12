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
    public class DistribuidoraService : BaseService<Distribuidora>, IDistribuidoraService
    {
        private readonly IDistribuidoraRepository _distribuidoraRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IEmpresaUsuarioService _empresaUsuarioService;
        private readonly IMapper _mapper;
        public DistribuidoraService(IDistribuidoraRepository distribuidoraRepository, IUsuarioService usuarioService, IEmpresaUsuarioService empresaUsuarioService, IMapper mapper) 
            : base(distribuidoraRepository)
        {
            _distribuidoraRepository = distribuidoraRepository;
            _usuarioService = usuarioService;
            _empresaUsuarioService = empresaUsuarioService;
            _mapper = mapper;
        }

        public Usuario AddUsuarioDistribuidora(IdentityUser usuarioIdentity, DistribuidoraVM distribuidora, string empresa_Global)
        {
            try
            {
                Usuario usuario = new Usuario(distribuidora.Nome, true, distribuidora.Cpf.ToString(), usuarioIdentity.Id, EnumPerfil.Distribuidora);
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

        public Distribuidora AddDistribuidora(DistribuidoraVM distribuidora)
        {
            try
            {
                Distribuidora distribuidoraEntidade = _mapper.Map<Distribuidora>(distribuidora);
                var distribuidoraEntidade2 = _distribuidoraRepository.Add(distribuidoraEntidade);

                return distribuidoraEntidade2;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void UpdateDistribuidora(DistribuidoraVM obj)
        {
            var usuario = _usuarioService.GetById(obj.Id_Usuario);
            usuario.Nome = obj.Nome;
            usuario.Cpf = obj.Cpf;
            _usuarioService.Update(usuario);

            var distribuidora = _distribuidoraRepository.GetById(obj.Id_Distribuidora);
            distribuidora.AtualizarDistribuidora(obj.Nome,obj.Cpf,obj.Email,obj.Telefone);
            _distribuidoraRepository.Update(distribuidora);
        }

        public void RemoverDistribuidora(int id)
        {
            var distribuidora = _distribuidoraRepository.GetById(id);
            var usuario = _usuarioService.GetById(distribuidora.Id_Usuario);
            usuario.Ativo = false;
            _usuarioService.Update(usuario);
        }
    }
}

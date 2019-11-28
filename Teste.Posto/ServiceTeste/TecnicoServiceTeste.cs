using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.Services;
using Posto.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Posto.ServiceTeste
{
    class TecnicoServiceTeste : BaseService<Tecnico>, ITecnicoService
    {
        private readonly ITecnicoRepository _tecnicoRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IEnderecoService _enderecoService;
        private readonly IMapper _mapper;
        private readonly IEmpresaUsuarioService _empresaUsuarioService;
        public TecnicoServiceTeste(ITecnicoRepository tecnicoRepository, IUsuarioService usuarioService, IEnderecoService enderecoService, IMapper mapper, IEmpresaUsuarioService empresaUsuarioService)
            : base(tecnicoRepository)
        {
            _tecnicoRepository = tecnicoRepository;
            _usuarioService = usuarioService;
            _enderecoService = enderecoService;
            _empresaUsuarioService = empresaUsuarioService;
            _mapper = mapper;
        }

        public Endereco AddEnderecoTecnico(TecnicoVM tecnico)
        {
            throw new NotImplementedException();
        }

        public void AddTecnico(TecnicoVM tecnico)
        {
            throw new NotImplementedException();
        }

        public Usuario AddUsuarioTecnico(IdentityUser usuarioIdentity, TecnicoVM tecnico, int id_Endereco, string empresa_Global)
        {
            throw new NotImplementedException();
        }

        public TecnicoVM GetTecnico(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveTecnico(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEndereco(TecnicoVM tecnico)
        {
            throw new NotImplementedException();
        }

        public void UpdateTecnico(TecnicoVM tecnico)
        {
            throw new NotImplementedException();
        }

        public Usuario UpdateUsuario(TecnicoVM tecnico)
        {
            throw new NotImplementedException();
        }
    }
}

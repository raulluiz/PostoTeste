﻿using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Posto.ServiceTeste
{
    public class UsuarioServiceTeste : BaseService<Usuario>, IUsuarioService
    {
        public readonly IUsuarioRepository _usuarioRepository;
        public UsuarioServiceTeste(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
    }
}

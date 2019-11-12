using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Services
{
    public class EmpresaUsuarioService : BaseService<EmpresaUsuario>, IEmpresaUsuarioService
    {
        private readonly IEmpresaUsuarioRepository _empresaUsuarioRepository;
        public EmpresaUsuarioService(IEmpresaUsuarioRepository empresaUsuarioRepository) : base(empresaUsuarioRepository)
        {
            _empresaUsuarioRepository = empresaUsuarioRepository;
        }

    }
}

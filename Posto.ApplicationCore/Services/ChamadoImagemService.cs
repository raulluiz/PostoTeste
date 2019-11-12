using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Services
{
    public class ChamadoImagemService : BaseService<ChamadoImagem>, IChamadoImagemService
    {
        private readonly IChamadoImagemRepository _chamadoImagemRepository;
        public ChamadoImagemService(IChamadoImagemRepository chamadoImagemRepository) : base(chamadoImagemRepository)
        {
            _chamadoImagemRepository = chamadoImagemRepository;
        }

        //public List<Empresa> GetEmpresaPorAtivo(string nome)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

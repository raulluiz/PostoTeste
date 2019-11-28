using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto.ServiceTeste
{
    class ChamadoServiceTeste : BaseService<Chamado>, IChamadoService
    {
        public Chamado Add(Chamado entity)
        {
            throw new NotImplementedException();
        }

        public void AdicionarTecnicoChamado(int id_Tecnico, int id_Chamado)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Chamado> Get(Expression<Func<Chamado, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Chamado> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllImagesChamado(int id_chamado)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetAllSeries(int id_empresa)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetAllSubConjuntos(int id_serie)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetAllTecnicos(int id_empresa)
        {
            throw new NotImplementedException();
        }

        public Chamado GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChamadoVM> GetChamadosApp(int idUsuario, string perfil)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetProdutosChamado(ChamadoVM chamado)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetSubConjuntosChamado(ChamadoVM chamado)
        {
            throw new NotImplementedException();
        }

        public void Remove(Chamado entity)
        {
            throw new NotImplementedException();
        }

        public Chamado SalvarChamado(ChamadoVM chamado, int id_Usuario)
        {
            throw new NotImplementedException();
        }

        public void SalvarChamadoTecnico(IFormFileCollection files, ChamadoVM chamadoVM, int id_usuario)
        {
            throw new NotImplementedException();
        }

        public void SalvarImagensCliente(Chamado chamado, byte[] imagem, int Id_Usuario)
        {
            throw new NotImplementedException();
        }

        public void Update(Chamado entity)
        {
            throw new NotImplementedException();
        }
    }
}

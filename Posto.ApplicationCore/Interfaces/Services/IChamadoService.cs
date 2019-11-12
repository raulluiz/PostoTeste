using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.ViewModels;
using System.Collections.Generic;

namespace Posto.ApplicationCore.Interfaces.Services
{
    public interface IChamadoService : IBaseService<Chamado>
    {
        //List<Empresa> GetEmpresaPorAtivo(string nome);
        Chamado SalvarChamado(ChamadoVM chamado, int id_Usuario);
        void SalvarImagensCliente(Chamado chamado, byte[] imagem, int Id_Usuario);
        void AdicionarTecnicoChamado(int id_Tecnico, int id_Chamado);
        List<SelectListItem> GetAllTecnicos(int id_empresa);
        List<SelectListItem> GetSubConjuntosChamado(ChamadoVM chamado);
        List<SelectListItem> GetAllSeries(int id_empresa);
        List<SelectListItem> GetProdutosChamado(ChamadoVM chamado);
        List<SelectListItem> GetAllSubConjuntos(int id_serie);
        List<string> GetAllImagesChamado(int id_chamado);
        void SalvarChamadoTecnico(IFormFileCollection files, ChamadoVM chamadoVM, int id_usuario);
        IEnumerable<ChamadoVM> GetChamadosApp(int idUsuario, string perfil);
    }
}
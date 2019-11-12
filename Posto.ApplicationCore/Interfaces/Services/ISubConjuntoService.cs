using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.ViewModels;
using System.Collections.Generic;

namespace Posto.ApplicationCore.Interfaces.Services
{
    public interface ISubConjuntoService : IBaseService<SubConjunto>
    {
        List<SubConjuntoVM> GetAllSubConjuntoVMs(List<SerieSubConjunto> idsSubConjuntos);
    }
}
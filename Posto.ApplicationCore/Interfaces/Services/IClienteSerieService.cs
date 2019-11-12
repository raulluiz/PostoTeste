using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.ApplicationCore.Interfaces.Services
{
    public interface IClienteSerieService : IBaseService<ClienteSerie>
    {
        void CadastroClienteSerie(int id_Cliente, List<int> series);
        void UpdateClienteSerie(int id_Cliente, List<int> series);
    }
}

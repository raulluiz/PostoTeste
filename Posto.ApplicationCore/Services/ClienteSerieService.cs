using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Posto.ApplicationCore.Services
{
    public class ClienteSerieService : BaseService<ClienteSerie>, IClienteSerieService
    {
        private readonly IClienteSerieRepository _clienteSerieRepository;
        public ClienteSerieService(IClienteSerieRepository clienteSerieRepository) : base(clienteSerieRepository)
        {
            _clienteSerieRepository = clienteSerieRepository;
        }

        public void CadastroClienteSerie(int id_Cliente, List<int> series)
        {
            foreach (var item in series)
            {
                ClienteSerie clienteSerie = new ClienteSerie(id_Cliente,item);
                _clienteSerieRepository.Add(clienteSerie);
            }
        }

        public void UpdateClienteSerie(int id_Cliente, List<int> series)
        {
            var seriesAll = _clienteSerieRepository.Get(s => s.Id_Cliente == id_Cliente);

            if(seriesAll.Count() != 0)
            {
                //RemoveAll
                foreach (var item in seriesAll)
                {
                    _clienteSerieRepository.Remove(item);
                }
            }

            foreach (var item in series)
            {
                ClienteSerie clienteSerie = new ClienteSerie(id_Cliente, item);
                _clienteSerieRepository.Add(clienteSerie);
            }

        }
    }
}

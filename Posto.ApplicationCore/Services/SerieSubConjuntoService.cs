using AutoMapper;
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
    public class SerieSubConjuntoService : BaseService<SerieSubConjunto>, ISerieSubConjuntoService
    {
        private readonly ISerieSubConjuntoRepository _serieSubConjuntoRepository;
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IMapper _mapper;
        public SerieSubConjuntoService(ISerieSubConjuntoRepository serieSubConjuntoRepository, IMapper mapper, IEquipamentoRepository equipamentoRepository) : base(serieSubConjuntoRepository)
        {
            _serieSubConjuntoRepository = serieSubConjuntoRepository;
            _mapper = mapper;
            _equipamentoRepository = equipamentoRepository;
        }

        public List<Empresa> GetEmpresaPorAtivo(string nome)
        {
            throw new NotImplementedException();
        }

        public void SalvarEquipamentoSubConjunto(EquipamentoVM equipamentoVM)
        {
            var equipamento = _mapper.Map<Equipamento>(equipamentoVM);
            _equipamentoRepository.Add(equipamento);
        }

        public void UpdateEquipamentoSubConjunto(EquipamentoVM equipamentoVM)
        {
            var equipamento = _equipamentoRepository.Get(s => s.Id_Equipamento == equipamentoVM.Id_Equipamento && s.IdEmpresa == equipamentoVM.IdEmpresa).FirstOrDefault();
            equipamento.Ativo = equipamentoVM.Ativo;
            equipamento.Modelo_Bomba = equipamentoVM.Modelo_Bomba;
            equipamento.Numero_Serie = equipamentoVM.Numero_Serie;
            equipamento.Tipo = equipamentoVM.Tipo;
            _equipamentoRepository.Update(equipamento);
        }

        public void RemoverEquipamentoSubConjunto(int id, int idEmpresa)
        {
            var serie = _equipamentoRepository.Get(s => s.Id_Equipamento == id && s.IdEmpresa == idEmpresa).FirstOrDefault();
            serie.Inativar();
            _equipamentoRepository.Update(serie);
        }
    }
}

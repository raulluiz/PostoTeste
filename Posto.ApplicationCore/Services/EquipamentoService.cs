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
    public class EquipamentoService : BaseService<Equipamento>, IEquipamentoService
    {
        private readonly IEquipamentoRepository _serieRepository;
        private readonly IMapper _mapper;
        public EquipamentoService(IEquipamentoRepository serieRepository, IMapper mapper) : base(serieRepository)
        {
            _serieRepository = serieRepository;
            _mapper = mapper;
        }

        //public List<Empresa> GetEmpresaPorAtivo(string nome)
        //{
        //    throw new NotImplementedException();
        //}

        public string SalvarEquipamento(EquipamentoVM equipamentoVM)
        {
            var serie = _mapper.Map<Equipamento>(equipamentoVM);
            _serieRepository.Add(serie);
            return "Salvo com sucesso!";
        }

        public string UpdateEquipamento(EquipamentoVM equipamentoVM)
        {
            var serie = _serieRepository.Get(s => s.Id_Equipamento == equipamentoVM.Id_Equipamento && s.IdEmpresa == equipamentoVM.IdEmpresa).FirstOrDefault();
            serie.Ativo = equipamentoVM.Ativo;
            serie.Modelo_Bomba = equipamentoVM.Modelo_Bomba;
            serie.Numero_Serie = equipamentoVM.Numero_Serie;
            serie.Tipo = equipamentoVM.Tipo;
            _serieRepository.Update(serie);

            return "Alterado com sucesso!";
        }

        public string RemoverEquipamento(int id, int idEmpresa)
        {
            var serie = _serieRepository.Get(s => s.Id_Equipamento == id && s.IdEmpresa == idEmpresa).FirstOrDefault();
            serie.Inativar();
            _serieRepository.Update(serie);
            return "Removido com sucesso!";
        }
    }
}

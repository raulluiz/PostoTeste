﻿using AutoMapper;
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
    public class SubConjuntoService : BaseService<SubConjunto>, ISubConjuntoService
    {
        private readonly ISubConjuntoRepository  _subConjuntoRepository;
        private readonly IMapper _mapper;
        public SubConjuntoService(ISubConjuntoRepository subConjuntoRepository, IMapper mapper) : base(subConjuntoRepository)
        {
            _subConjuntoRepository = subConjuntoRepository;
            _mapper = mapper;
        }

        public List<SubConjuntoVM> GetAllSubConjuntoVMs(List<SerieSubConjunto> idsSubConjuntos)
        {
            List<SubConjuntoVM> subConjuntos = new List<SubConjuntoVM>();
            foreach (var item in idsSubConjuntos)
            {
                var subConjunto = _subConjuntoRepository.GetById(item.Id_SubConjunto);
                subConjuntos.Add(_mapper.Map<SubConjuntoVM>(subConjunto));
            }
            return subConjuntos;
        }

        //public void SalvarProduto(ProdutoVM produtoVM)
        //{
        //    var produto = _mapper.Map<Produto>(produtoVM);
        //    _produtoRepository.Add(produto);
        //}

        //public void UpdateProduto(ProdutoVM produtoVM)
        //{
        //    var produto = _produtoRepository.Get(p => p.Id_Produto == produtoVM.Id_Produto && p.Id_Serie == produtoVM.Id_Serie && p.IdEmpresa == produtoVM.IdEmpresa).FirstOrDefault();
        //    produto.Ativo = produtoVM.Ativo;
        //    produto.Nome = produtoVM.Nome;
        //    produto.Ativo = true;
        //    _produtoRepository.Update(produto);
        //}

        //public void RemoverProduto(int idEmpresa, int id_Serie, int id_Produto)
        //{
        //    var produto = _produtoRepository.Get(p => p.Id_Produto == id_Produto && p.Id_Serie == id_Serie && p.IdEmpresa == idEmpresa).FirstOrDefault();
        //    produto.Inativar();
        //    _produtoRepository.Update(produto);
        //}
    }
}

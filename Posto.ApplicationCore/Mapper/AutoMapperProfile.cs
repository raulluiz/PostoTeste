using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Posto.Web.Mapper
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {

            #region Entidades
            CreateMap<Usuario, UsuarioVM>();
            CreateMap<UsuarioVM, Usuario>();

            CreateMap<Usuario, UsuarioIdentityVM>();
            CreateMap<UsuarioIdentityVM, Usuario>();

            CreateMap<Empresa, EmpresaVM>();
            CreateMap<EmpresaVM, Empresa>();

            CreateMap<Cliente, ClienteVM>();
            CreateMap<ClienteVM, Cliente>();

            CreateMap<Tecnico, TecnicoVM>();
            CreateMap<TecnicoVM, Tecnico>();

            CreateMap<EquipamentoVM, Equipamento>();
            CreateMap<Equipamento, EquipamentoVM>();

            CreateMap<ProdutoVM, Produto>();
            CreateMap<Produto, ProdutoVM>();

            CreateMap<ChamadoVM, Chamado>();
            CreateMap<Chamado, ChamadoVM>();

            CreateMap<SubConjuntoVM, SubConjunto>();
            CreateMap<SubConjunto, SubConjuntoVM>();

            CreateMap<DistribuidoraVM, Distribuidora>();
            CreateMap<Distribuidora, DistribuidoraVM>();
            #endregion
        }
    }
}

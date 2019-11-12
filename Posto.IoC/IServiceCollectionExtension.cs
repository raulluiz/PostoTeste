using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Posto.ApplicationCore.Interfaces.Repository;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.Services;
using Posto.Infrastructure.Context;
using Posto.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.IoC
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IExemploService, ExemploService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IEmpresaUsuarioService, EmpresaUsuarioService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ITecnicoService, TecnicoService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IEquipamentoService, EquipamentoService>();
            services.AddScoped<IImagemService, ImagemService>();
            services.AddScoped<IClienteSerieService, ClienteSerieService>();
            services.AddScoped<IChamadoService, ChamadoService>();
            services.AddScoped<IChamadoImagemService, ChamadoImagemService>();
            services.AddScoped<ISubConjuntoService, SubConjuntoService>();
            services.AddScoped<ISerieSubConjuntoService, SerieSubConjuntoService>();
            services.AddScoped<IChamadoSubConjuntoService, ChamadoSubConjuntoService>();
            services.AddScoped<IChamadoProdutoService, ChamadoProdutoService>();
            services.AddScoped<IDistribuidoraService, DistribuidoraService>();

            RegisterRepository(services);
            RegisterContext(services);

            return services;
        }

        public static IServiceCollection RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IExemploRepository, ExemploRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEmpresaUsuarioRepository, EmpresaUsuarioRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITecnicoRepository, TecnicoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IEquipamentoRepository, EquipamentoRepository>();
            services.AddScoped<IImagemRepository, ImagemRepository>();
            services.AddScoped<IClienteSerieRepository, ClienteSerieRepository>();
            services.AddScoped<IChamadoRepository, ChamadoRepository>();
            services.AddScoped<IChamadoImagemRepository, ChamadoImagemRepository>();
            services.AddScoped<ISubConjuntoRepository, SubConjuntoRepository>();
            services.AddScoped<ISerieSubConjuntoRepository, SerieSubConjuntoRepository>();
            services.AddScoped<IChamadoSubConjuntoRepository, ChamadoSubConjuntoRepository>();
            services.AddScoped<IChamadoProdutoRepository, ChamadoProdutoRepository>();
            services.AddScoped<IDistribuidoraRepository, DistribuidoraRepository>();

            return services;
        }
        public static IServiceCollection RegisterContext(this IServiceCollection services)
        {
            services.AddScoped<PostoContext>();
            return services;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Posto.ApplicationCore.Entities;
using Posto.Infrastructure.EntityConfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Posto.Infrastructure.Context
{
    public class PostoContext : DbContext
    {
        public PostoContext() { }
        public PostoContext(DbContextOptions<PostoContext> opcoes) : base(opcoes) { }

        public DbSet<Exemplo> Exemplo { get; set; }
        public DbSet<ExemploItem> ExemploItem { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<EmpresaUsuario> EmpresaUsuario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Tecnico> Tecnico { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
        public DbSet<ClienteSerie> ClienteSerie { get; set; }
        public DbSet<Chamado> Chamado { get; set; }
        public DbSet<ChamadoImagem> ChamadoImagem { get; set; }
        public DbSet<SubConjunto> SubConjunto { get; set; }
        public DbSet<SerieSubConjunto> SerieSubConjunto { get; set; }
        public DbSet<ChamadoSubConjunto> ChamadoSubConjunto { get; set; }
        public DbSet<ChamadoProduto> ChamadoProduto { get; set; }
        public DbSet<Distribuidora> Distribuidora { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration.Remove<PluralizingTableNameConvention>(); //plularização de objetos
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //deleção em cascata de filho
            modelBuilder.ApplyConfiguration(new ExemploConfig());
            modelBuilder.ApplyConfiguration(new ExemploItemConfig());
            modelBuilder.ApplyConfiguration(new EmpresaConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new EmpresaUsuarioConfig());
            modelBuilder.ApplyConfiguration(new EnderecoConfig());
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new TecnicoConfig());
            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            modelBuilder.ApplyConfiguration(new EquipamentoConfig());
            modelBuilder.ApplyConfiguration(new ImagemConfig());
            modelBuilder.ApplyConfiguration(new ClienteSerieConfig());
            modelBuilder.ApplyConfiguration(new ChamadoConfig());
            modelBuilder.ApplyConfiguration(new ChamadoImagemConfig());
            modelBuilder.ApplyConfiguration(new SubConjuntoConfig());
            modelBuilder.ApplyConfiguration(new SerieSubConjuntoConfig());
            modelBuilder.ApplyConfiguration(new ChamadoSubConjuntoConfig());
            modelBuilder.ApplyConfiguration(new ChamadoProdutoConfig());
            modelBuilder.ApplyConfiguration(new DistribuidoraConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}

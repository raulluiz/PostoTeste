using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posto.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Posto.Infrastructure.EntityConfig
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(c => new { c.Id_Produto,  c.IdEmpresa, c.Id_Serie });
            builder.Property(c => c.Id_Produto).ValueGeneratedOnAdd();
            builder.Property(c => c.Nome);
            builder.Property(c => c.IdEmpresa);
            builder.Property(c => c.Ativo);
            builder.Property(c => c.Id_Serie);
        }
    }
}
